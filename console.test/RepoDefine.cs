namespace console.test
{
    #region 公交车位置查询结果定义
    public class RepoBus
    {
        public RepoStatus status;
        public RepoResultBus[] result;
    }

    public class RepoStatus
    {
        public string code;
        public string msg;
    }

    public class RepoResultBus
    {
        public string busid;
        public double lng;
        public double lat;
        public double velocity;
        public string isArrvLft;
        public string stationSeqNum;
        public string status;
        public string buslineId;
        public string actTime;
        public string cardId;
        public string orgName;
        public double averageVelocity;
        public string coordinate;
        public string busLineName;
        public string nextStation;
        public string nextStationDistance;
        public string nextStationMinutes;
    }
    #endregion

    #region 公交车线路站点查询结果定义
    public class RepoLine
    {
        public RepoStatus status;
        public RepoResultLine result;
    }

    public class RepoResultLine
    {
        public string id;
        public string area;
        public string lineName;
        public string startStationName;
        public string endStationName;
        public string ticketPrice;
        public string operationTime;
        public string owner;
        public string linePoints;
        public string updateTime;
        public string state;

        public RepoResultStation[] stations;
    }

    public class RepoResultStation
    {
        public string id;
        public string area;
        public string stationName;
        public double lng;
        public double lat;
        public string buslines;
        public string state;
        public string updateTime;
        public string distance;
        public string busLineList;
    }
    #endregion


    #region 线路名称查询结果定义
    public class RepoLineName
    {
        public RepoStatus status;
        public RepoResultLine[] result;
    }

    public class Line
    {
        public string id;
        public string lineName;
        public string startStationName;
        public string endStationName;
        public string updateTime;
    }
    #endregion

}