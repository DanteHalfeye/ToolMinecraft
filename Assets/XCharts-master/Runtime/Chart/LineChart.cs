using UnityEngine;
using System.Xml;
using System.IO;
using System.Collections.Generic;

namespace XCharts.Runtime
{
    [AddComponentMenu("XCharts/LineChart", 13)]
    [ExecuteInEditMode]
    [RequireComponent(typeof(RectTransform))]
    [DisallowMultipleComponent]
    [HelpURL("https://xcharts-team.github.io/docs/configuration")]
    public class LineChart : BaseChart
    {
        public TextAsset xmlData;

        protected override void DefaultChart()
        {
            EnsureChartComponent<GridCoord>();
            EnsureChartComponent<XAxis>();
            EnsureChartComponent<YAxis>();

            RemoveData();
            Line.AddDefaultSerie(this, GenerateDefaultSerieName());
            LoadDataFromXML();
        }

        public void LoadDataFromXML()
        {
            if (xmlData == null)
            {
                Debug.LogError("XML data file is not assigned.");
                return;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlData.text);
            XmlNodeList dataPoints = xmlDoc.SelectNodes("//ChartData/DataPoint");

            List<string> xLabels = new List<string>();
            List<float> yValues = new List<float>();

            foreach (XmlNode dataPoint in dataPoints)
            {
                string xValue = dataPoint["X"]?.InnerText;
                float yValue;
                if (!string.IsNullOrEmpty(xValue) && float.TryParse(dataPoint["Y"]?.InnerText, out yValue))
                {
                    xLabels.Add(xValue);
                    yValues.Add(yValue);
                }
            }

            if (xLabels.Count > 0 && yValues.Count > 0)
            {
                var serie = GetSerie(0);
                if (serie != null)
                {
                    serie.ClearData();
                    for (int i = 0; i < xLabels.Count; i++)
                    {
                        AddXAxisData(xLabels[i]);
                        serie.AddData(yValues[i]);
                    }
                }
            }
        }

        public void DefaultAreaLineChart()
        {
            CheckChartInit();
            var serie = GetSerie(0);
            if (serie == null) return;
            serie.EnsureComponent<AreaStyle>();
        }

        public void DefaultSmoothLineChart()
        {
            CheckChartInit();
            var serie = GetSerie(0);
            if (serie == null) return;
            serie.lineType = LineType.Smooth;
        }

        public void DefaultSmoothAreaLineChart()
        {
            CheckChartInit();
            var serie = GetSerie(0);
            if (serie == null) return;
            serie.EnsureComponent<AreaStyle>();
            serie.lineType = LineType.Smooth;
        }

        public void DefaultStackLineChart()
        {
            CheckChartInit();
            var serie1 = GetSerie(0);
            if (serie1 == null) return;
            serie1.stack = "stack1";
            var serie2 = Line.AddDefaultSerie(this, GenerateDefaultSerieName());
            serie2.stack = "stack1";
        }

        public void DefaultStackAreaLineChart()
        {
            CheckChartInit();
            var serie1 = GetSerie(0);
            if (serie1 == null) return;
            serie1.EnsureComponent<AreaStyle>();
            serie1.stack = "stack1";
            var serie2 = Line.AddDefaultSerie(this, GenerateDefaultSerieName());
            serie2.EnsureComponent<AreaStyle>();
            serie2.stack = "stack1";
        }

        public void DefaultStepLineChart()
        {
            CheckChartInit();
            var serie = GetSerie(0);
            if (serie == null) return;
            serie.lineType = LineType.StepMiddle;
        }

        public void DefaultDashLineChart()
        {
            CheckChartInit();
            var serie = GetSerie(0);
            if (serie == null) return;
            serie.lineType = LineType.Normal;
            serie.lineStyle.type = LineStyle.Type.Dashed;
        }

        public void DefaultTimeLineChart()
        {
            CheckChartInit();
            var xAxis = GetChartComponent<XAxis>();
            xAxis.type = Axis.AxisType.Time;
        }

        public void DefaultLogLineChart()
        {
            CheckChartInit();
            var yAxis = GetChartComponent<YAxis>();
            yAxis.type = Axis.AxisType.Log;
        }
    }
}