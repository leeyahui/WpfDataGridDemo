using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfDataGridDemo
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        List<DistrictModel> dmList = new List<DistrictModel>();
        List<MapSpotModel> MSList = new List<MapSpotModel>();
        public void SelectMS()
        {
            #region 构造行政区数据
            string[] str1 = { "XX县", "ZZ县", "CC县", "VV县" };
            string[] str2 = { "QQQ", "WWW", "AAA", "SSS", "EEE", "DDD", "RRR" };
            #endregion 构造行政区数据_end
            //随机数
            Random rd0 = new Random();
            for (int i = 0; i < str1.Count(); i++)
            {
                int cd = 101 + i;
                dmList.Add(new DistrictModel() { Id = i + 1, Code = cd, Name = str1[i] });
                #region 构造图斑数据
                for (int j = 0; j < str2.Count(); j++)
                {
                    #region 生成随机图斑及面积个数并计算其值

                    #region 所有图斑个数
                    int AllNumber1 = rd0.Next(1, 1000);
                    #endregion 所有图斑个数_end

                    #region 核查单位已核查图斑个数
                    //总共
                    int HCTureNumber1 = rd0.Next(1, AllNumber1);
                    //已核查通过个数
                    int HCTruePassNumber1 = rd0.Next(1, HCTureNumber1);
                    //已核查不通过个数
                    int HCTrueNoPassNumber1 = HCTureNumber1 - HCTruePassNumber1;
                    //通过率
                    string HCTruePassingRate1 = (Math.Round(((double)HCTruePassNumber1 / HCTureNumber1) * 100)) + "%";
                    #endregion 核查单位已核查图斑个数_end

                    #region 核查单位已核查图斑个数
                    //总共
                    int JLTureNumber1 = rd0.Next(1, AllNumber1);
                    //已核查通过个数
                    int JLTruePassNumber1 = rd0.Next(1, JLTureNumber1);
                    //已核查不通过个数
                    int JLTrueNoPassNumber = JLTureNumber1 - JLTruePassNumber1;
                    //通过率
                    string JLTruePassingRate1 = (Math.Round(((double)JLTruePassNumber1 / JLTureNumber1) * 100)) + "%";
                    #endregion 核查单位已核查图斑个数_end

                    #region 所有图斑面积
                    double AllArea1 = Math.Round((rd0.NextDouble() * 1000), 2);
                    double HCTrueArea1 = rd0.Next(1, (int)AllArea1);
                    double JLTrueArea1 = rd0.Next(1, (int)AllArea1);
                    #endregion

                    #endregion 
                    MSList.Add(new MapSpotModel()
                    {
                        Id = i + 1,
                        Name = str2[j],
                        Code = cd,
                        AllNumber = AllNumber1,
                        AllArea = AllArea1,
                        HCTureNumber = HCTureNumber1,
                        HCTrueArea = HCTrueArea1,
                        HCTruePassNumber = HCTruePassNumber1,
                        HCTrueNoPassNumber = HCTrueNoPassNumber1,
                        HCTruePassingRate = HCTruePassingRate1,
                        JLTureNumber = JLTureNumber1,
                        JLTrueArea = JLTrueArea1,
                        JLTruePassNumber = JLTruePassNumber1,
                        JLTrueNoPassNumber = JLTrueNoPassNumber,
                        JLTruePassingRate = JLTruePassingRate1,
                        DistrictModels = new DistrictModel() { Id = i, Code = cd, Name = str2[j] }
                    });
                }
                #endregion 构造图斑数据_end
            }
            dategrid1.ItemsSource = dmList;
            dategrid2.ItemsSource = MSList;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SelectMS();
        }
    }

    /// <summary>
    /// 行政区表
    /// </summary>
    public class DistrictModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        private int id;
        /// <summary>
        /// 代码
        /// </summary>
        private int code;
        /// <summary>
        /// 名称
        /// </summary>
        private string name;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        /// <summary>
        /// 代码
        /// </summary>
        public int Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

    }
    /// <summary>
    /// 表
    /// </summary>
    public class MapSpotModel
    {
        private int id;
        //名称
        private string name;
        //代码
        private int code;
        //个数
        private int allNumber;
        //面积
        private double allArea;

        //个数
        private int hCTureNumber;
        //面积
        private double hCTrueArea;
        //通过个数
        private int hCTruePassNumber;
        //不通过个数
        private int hCTrueNoPassNumber;
        //通过率
        private string hCTruePassingRate;

        //个数
        private int jLTureNumber;
        //面积
        private double jLTrueArea;
        //通过个数
        private int jLTruePassNumber;
        //不通过个数
        private int jLTrueNoPassNumber;
        //通过率
        private string jLTruePassingRate;

        private DistrictModel districtModels;
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        /// <summary>
        /// 代码
        /// </summary>
        public int Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        /// <summary>
        /// 个数
        /// </summary>
        public int AllNumber
        {
            get
            {
                return allNumber;
            }

            set
            {
                allNumber = value;
            }
        }

        /// <summary>
        /// 面积
        /// </summary>
        public double AllArea
        {
            get
            {
                return allArea;
            }

            set
            {
                allArea = value;
            }
        }

        /// <summary>
        /// 个数
        /// </summary>
        public int HCTureNumber
        {
            get
            {
                return hCTureNumber;
            }

            set
            {
                hCTureNumber = value;
            }
        }

        /// <summary>
        /// 面积
        /// </summary>
        public double HCTrueArea
        {
            get
            {
                return hCTrueArea;
            }

            set
            {
                hCTrueArea = value;
            }
        }

        /// <summary>
        /// 通过个数
        /// </summary>
        public int HCTruePassNumber
        {
            get
            {
                return hCTruePassNumber;
            }

            set
            {
                hCTruePassNumber = value;
            }
        }

        /// <summary>
        /// 不通过个数
        /// </summary>
        public int HCTrueNoPassNumber
        {
            get
            {
                return hCTrueNoPassNumber;
            }

            set
            {
                hCTrueNoPassNumber = value;
            }
        }

        /// <summary>
        /// 通过率
        /// </summary>
        public string HCTruePassingRate
        {
            get
            {
                return hCTruePassingRate;
            }

            set
            {
                hCTruePassingRate = value;
            }
        }

        /// <summary>
        /// 个数
        /// </summary>
        public int JLTureNumber
        {
            get
            {
                return jLTureNumber;
            }

            set
            {
                jLTureNumber = value;
            }
        }

        /// <summary>
        /// 面积
        /// </summary>
        public double JLTrueArea
        {
            get
            {
                return jLTrueArea;
            }

            set
            {
                jLTrueArea = value;
            }
        }

        /// <summary>
        /// 通过个数
        /// </summary>
        public int JLTruePassNumber
        {
            get
            {
                return jLTruePassNumber;
            }

            set
            {
                jLTruePassNumber = value;
            }
        }

        /// <summary>
        /// 不通过个数
        /// </summary>
        public int JLTrueNoPassNumber
        {
            get
            {
                return jLTrueNoPassNumber;
            }

            set
            {
                jLTrueNoPassNumber = value;
            }
        }

        /// <summary>
        /// 监理单位已审核图斑-通过率
        /// </summary>
        public string JLTruePassingRate
        {
            get
            {
                return jLTruePassingRate;
            }

            set
            {
                jLTruePassingRate = value;
            }
        }

        public DistrictModel DistrictModels
        {
            get
            {
                return districtModels;
            }

            set
            {
                districtModels = value;
            }
        }
    }
}
