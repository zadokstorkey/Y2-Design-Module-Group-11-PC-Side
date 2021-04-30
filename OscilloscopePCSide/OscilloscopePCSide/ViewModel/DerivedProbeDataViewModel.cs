using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public class DerivedProbeDataViewModel : ViewModelBase, IDerivedProbeDataViewModel
    {
        private IDerivedSourceConfigViewModel _sourceConfig;

        public ISourceConfigViewModelBase SourceConfig
        {
            get
            {
                return _sourceConfig;
            }
        }

        public IDerivedSourceConfigViewModel DerivedSourceConfig
        {
            get
            {
                return _sourceConfig;
            }
        }

        public string TracePath
        {
            get
            {
                if (!CanProcessFrame())
                {
                    return "M 0 4096 M 0 -4096 ";
                }
                List<int> tracePathHeights;
                if (_sourceConfig.Operation == "Add")
                {
                    tracePathHeights = ProcessFrameAddition(_sourceConfig.SourceConfigViewModel1.ProbeDataReadingService.ProbeData.MostRecentFrame.Heights, _sourceConfig.SourceConfigViewModel2.ProbeDataReadingService.ProbeData.MostRecentFrame.Heights);
                }
                else if (_sourceConfig.Operation == "Subtract")
                {
                    tracePathHeights = ProcessFrameSubtraction(_sourceConfig.SourceConfigViewModel1.ProbeDataReadingService.ProbeData.MostRecentFrame.Heights, _sourceConfig.SourceConfigViewModel2.ProbeDataReadingService.ProbeData.MostRecentFrame.Heights);
                }
                else if (_sourceConfig.Operation == "Average")
                {
                    tracePathHeights = ProcessFrameAveraging(_sourceConfig.SourceConfigViewModel1.ProbeDataReadingService.ProbeData.MostRecentFrame.Heights, _sourceConfig.SourceConfigViewModel2.ProbeDataReadingService.ProbeData.MostRecentFrame.Heights);
                }
                else if (_sourceConfig.Operation == "Invert")
                {
                    tracePathHeights = ProcessFrameInversion(_sourceConfig.SourceConfigViewModel1.ProbeDataReadingService.ProbeData.MostRecentFrame.Heights);
                }
                else
                {
                    throw new NotImplementedException("Operation not implemented");
                }
                return ConvertTracePathHeightsToTracePath(tracePathHeights);
            }
        }

        public string TracePathAverageOf10
        {
            get
            {
                if (!CanProcessFrame())
                {
                    return "M 0 4096 M 0 -4096 ";
                }
                List<int> tracePathHeights;
                List<int> probeData1Heights = _sourceConfig.SourceConfigViewModel1.ProbeDataReadingService.ProbeData.MostRecentFrame.Heights;
                for (var i = 0; i < probeData1Heights.Count; i++)
                {
                    for (var j = 1; j < 10; j++)
                    {
                        if (j < this._sourceConfig.SourceConfigViewModel1.ProbeDataReadingService.ProbeData.Frames.Count)
                        {
                            probeData1Heights[i] += this._sourceConfig.SourceConfigViewModel1.ProbeDataReadingService.ProbeData.Frames[j].Heights[i];
                        }
                    }
                    probeData1Heights[i] /= 10;
                }
                List<int> probeData2Heights;
                if (_sourceConfig.Operation == "Invert")
                {
                    tracePathHeights = ProcessFrameInversion(probeData1Heights);
                }
                else
                {
                    probeData2Heights = _sourceConfig.SourceConfigViewModel2.ProbeDataReadingService.ProbeData.MostRecentFrame.Heights;
                    for (var i = 0; i < probeData2Heights.Count; i++)
                    {
                        for (var j = 1; j < 10; j++)
                        {
                            if (j < this._sourceConfig.SourceConfigViewModel2.ProbeDataReadingService.ProbeData.Frames.Count)
                            {
                                probeData2Heights[i] += this._sourceConfig.SourceConfigViewModel2.ProbeDataReadingService.ProbeData.Frames[j].Heights[i];
                            }
                        }
                        probeData2Heights[i] /= 10;
                    }
                    if (_sourceConfig.Operation == "Add")
                    {
                        tracePathHeights = ProcessFrameAddition(probeData1Heights, probeData2Heights);
                    }
                    else if (_sourceConfig.Operation == "Subtract")
                    {
                        tracePathHeights = ProcessFrameSubtraction(probeData1Heights, probeData2Heights);
                    }
                    else if (_sourceConfig.Operation == "Average")
                    {
                        tracePathHeights = ProcessFrameAveraging(probeData1Heights, probeData2Heights);
                    }
                    else
                    {
                        throw new NotImplementedException("Operation not implemented");
                    }
                }
                return ConvertTracePathHeightsToTracePath(tracePathHeights);
            }
        }

        public string TracePathAverageOf50
        {
            get
            {
                if (!CanProcessFrame())
                {
                    return "M 0 4096 M 0 -4096 ";
                }
                List<int> tracePathHeights;
                List<int> probeData1Heights = _sourceConfig.SourceConfigViewModel1.ProbeDataReadingService.ProbeData.MostRecentFrame.Heights;
                for (var i = 0; i < probeData1Heights.Count; i++)
                {
                    for (var j = 1; j < 50; j++)
                    {
                        if (j < this._sourceConfig.SourceConfigViewModel1.ProbeDataReadingService.ProbeData.Frames.Count)
                        {
                            probeData1Heights[i] += this._sourceConfig.SourceConfigViewModel1.ProbeDataReadingService.ProbeData.Frames[j].Heights[i];
                        }
                    }
                    probeData1Heights[i] /= 50;
                }
                List<int> probeData2Heights;
                if (_sourceConfig.Operation == "Invert")
                {
                    tracePathHeights = ProcessFrameInversion(probeData1Heights);
                }
                else
                {
                    probeData2Heights = _sourceConfig.SourceConfigViewModel2.ProbeDataReadingService.ProbeData.MostRecentFrame.Heights;
                    for (var i = 0; i < probeData2Heights.Count; i++)
                    {
                        for (var j = 1; j < 10; j++)
                        {
                            if (j < this._sourceConfig.SourceConfigViewModel2.ProbeDataReadingService.ProbeData.Frames.Count)
                            {
                                probeData2Heights[i] += this._sourceConfig.SourceConfigViewModel2.ProbeDataReadingService.ProbeData.Frames[j].Heights[i];
                            }
                        }
                        probeData2Heights[i] /= 10;
                    }
                    if (_sourceConfig.Operation == "Add")
                    {
                        tracePathHeights = ProcessFrameAddition(probeData1Heights, probeData2Heights);
                    }
                    else if (_sourceConfig.Operation == "Subtract")
                    {
                        tracePathHeights = ProcessFrameSubtraction(probeData1Heights, probeData2Heights);
                    }
                    else if (_sourceConfig.Operation == "Average")
                    {
                        tracePathHeights = ProcessFrameAveraging(probeData1Heights, probeData2Heights);
                    }
                    else
                    {
                        throw new NotImplementedException("Operation not implemented");
                    }
                }
                return ConvertTracePathHeightsToTracePath(tracePathHeights);
            }
        }

        public DerivedProbeDataViewModel(IDerivedSourceConfigViewModel sourceConfig)
        {
            _sourceConfig = sourceConfig;
            RegisterProbeData1Watcher();
            RegisterProbeData2Watcher();
            this._sourceConfig.PropertyChanged += SourceConfig_PropertyChanged;
        }

        private bool CanProcessFrame()
        {
            // get the operation and the two source config view models
            var operation = _sourceConfig.Operation;
            var sourceConfigViewModel1 = _sourceConfig.SourceConfigViewModel1;
            var sourceConfigViewModel2 = _sourceConfig.SourceConfigViewModel2;

            // ensure that the first config is valid, if not return empty trace
            if (sourceConfigViewModel1 == null || sourceConfigViewModel1.COMPort == "" || sourceConfigViewModel1.ProbeDataReadingService.ProbeData.MostRecentFrame.Heights.Count == 0)
            {
                return false;
            }

            // ensure that the second config is valid, if not return empty trace
            if (operation != "Invert")
            {
                if (sourceConfigViewModel2 == null || sourceConfigViewModel2.COMPort == "" || sourceConfigViewModel2.ProbeDataReadingService.ProbeData.MostRecentFrame.Heights.Count == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private List<int> ProcessFrameAddition(List<int> source1Frame, List<int> source2Frame)
        {
            // get the operation and the two source config view models
            var operation = _sourceConfig.Operation;
            var sourceConfigViewModel1 = _sourceConfig.SourceConfigViewModel1;
            var sourceConfigViewModel2 = _sourceConfig.SourceConfigViewModel2;

            // simpler version with the same resolutions
            if (_sourceConfig.XResolution == sourceConfigViewModel1.XResolution && _sourceConfig.XResolution == sourceConfigViewModel2.XResolution)
            {
                return source1Frame.Zip(source2Frame, (h1, h2) => h1 + h2).ToList();
            }
            else
            {
                //todo
                throw new NotImplementedException();
            }
        }

        private List<int> ProcessFrameSubtraction(List<int> source1Frame, List<int> source2Frame)
        {
            // get the operation and the two source config view models
            var operation = _sourceConfig.Operation;
            var sourceConfigViewModel1 = _sourceConfig.SourceConfigViewModel1;
            var sourceConfigViewModel2 = _sourceConfig.SourceConfigViewModel2;

            // simpler version with the same resolutions
            if (_sourceConfig.XResolution == sourceConfigViewModel1.XResolution && _sourceConfig.XResolution == sourceConfigViewModel2.XResolution)
            {
                return source1Frame.Zip(source2Frame, (h1, h2) => h1 - h2).ToList();
            }
            else
            {
                //todo
                throw new NotImplementedException();
            }
        }

        private List<int> ProcessFrameAveraging(List<int> source1Frame, List<int> source2Frame)
        {
            // get the operation and the two source config view models
            var operation = _sourceConfig.Operation;
            var sourceConfigViewModel1 = _sourceConfig.SourceConfigViewModel1;
            var sourceConfigViewModel2 = _sourceConfig.SourceConfigViewModel2;

            // simpler version with the same resolutions
            if (_sourceConfig.XResolution == sourceConfigViewModel1.XResolution && _sourceConfig.XResolution == sourceConfigViewModel2.XResolution)
            {
                return source1Frame.Zip(source2Frame, (h1, h2) => (h1 + h2)/2).ToList();
            }
            else
            {
                //todo
                throw new NotImplementedException();
            }
        }

        private List<int> ProcessFrameInversion(List<int> source1Frame)
        {
            // get the operation and the two source config view models
            var operation = _sourceConfig.Operation;
            var sourceConfigViewModel1 = _sourceConfig.SourceConfigViewModel1;
            var sourceConfigViewModel2 = _sourceConfig.SourceConfigViewModel2;

            // simpler version with the same resolutions
            if (_sourceConfig.XResolution == sourceConfigViewModel1.XResolution)
            {
                return source1Frame.Select(h => -h).ToList();
            }
            else
            {
                //todo
                throw new NotImplementedException();
            }
        }

        private string ConvertTracePathHeightsToTracePath(List<int> pathHeights)
        {
            var tracePath = "M 0 4096 M 0 -4096 ";
            for (var i = 0; i < pathHeights.Count; i++)
            {
                tracePath += i == 0 ? "M " : "L ";
                tracePath += i.ToString() + " ";
                tracePath += (-pathHeights[i]).ToString() + " ";
            }
            return tracePath;
        }

        private void RegisterProbeData1Watcher()
        {
            if (this.DerivedSourceConfig.SourceConfigViewModel1 != null && this.DerivedSourceConfig.SourceConfigViewModel1.ProbeDataReadingService != null && this.DerivedSourceConfig.SourceConfigViewModel1.ProbeDataReadingService.ProbeData != null)
            {
                this.DerivedSourceConfig.SourceConfigViewModel1.ProbeDataReadingService.ProbeData.PropertyChanged -= ProbeData_PropertyChanged;
                this.DerivedSourceConfig.SourceConfigViewModel1.ProbeDataReadingService.ProbeData.PropertyChanged += ProbeData_PropertyChanged;
            }
        }

        private void RegisterProbeData2Watcher()
        {
            if (this.DerivedSourceConfig.Operation != "Invert" && this.DerivedSourceConfig.SourceConfigViewModel2 != null && this.DerivedSourceConfig.SourceConfigViewModel2.ProbeDataReadingService != null && this.DerivedSourceConfig.SourceConfigViewModel2.ProbeDataReadingService.ProbeData != null)
            {
                this.DerivedSourceConfig.SourceConfigViewModel2.ProbeDataReadingService.ProbeData.PropertyChanged -= ProbeData_PropertyChanged;
                this.DerivedSourceConfig.SourceConfigViewModel2.ProbeDataReadingService.ProbeData.PropertyChanged += ProbeData_PropertyChanged;
            }
        }

        private void ProbeData_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(TracePath));
            RaisePropertyChanged(nameof(TracePathAverageOf10));
            RaisePropertyChanged(nameof(TracePathAverageOf50));
        }

        private void SourceConfig_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IDerivedSourceConfigViewModel.SourceConfigViewModel1))
            {
                RegisterProbeData1Watcher();
                RegisterProbeData2Watcher();
            }
            else if (e.PropertyName == nameof(IDerivedSourceConfigViewModel.SourceConfigViewModel2) || e.PropertyName == nameof(IDerivedSourceConfigViewModel.Operation))
            {
                RegisterProbeData1Watcher();
                RegisterProbeData2Watcher();
            }
        }
    }
}
