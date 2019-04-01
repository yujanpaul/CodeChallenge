using System;
using System.Collections.Generic;
using System.Web;

namespace CodeChallenge.Models
{
    public class Case
    {
        #region Data Members
        private string _authNum;
        private int _caseNumber;
        private string _status;
        private DateTime _approvalDate;
        private int _servCode;
        private string _servDescription;
        private string _siteName;
        private DateTime _expData;
        private DateTime _lastUpdate;
        private List<Procedure> _procedures;
        #endregion

        #region Constructor
        public Case()
        { }
        public Case(string authNum, int caseNumber, string status, DateTime approvalDate,
            int servCode, string servDescription, string siteName, DateTime expData,
            DateTime lastUpdate, List<Procedure> procedures)
        {
            AuthNum = authNum;
            CaseNumber = caseNumber;
            Status = status;
            ApprovalDate = approvalDate;
            ServCode = servCode;
            ServDescription = servDescription;
            SiteName = siteName;
            ExpDate = expData;
            LastUpdate = lastUpdate;
            Procedures = procedures;
        }
        #endregion

        #region Properties
        public string AuthNum
        {
            get
            {
                return this._authNum;
            }
            set
            {
                this._authNum = value;
            }
        }
        public int CaseNumber
        {
            get
            {
                return this._caseNumber;
            }
            set
            {
                this._caseNumber = value;
            }
        }
        public string Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }
        public DateTime ApprovalDate
        {
            get
            {
                if (this._approvalDate == null)
                    this._approvalDate = new DateTime();
                return this._approvalDate;
            }
            set
            {
                this._approvalDate = value;
            }
        }
        public int ServCode
        {
            get
            {
                return this._servCode;
            }
            set
            {
                this._servCode = value;
            }
        }
        public string ServDescription
        {
            get
            {
                return HttpUtility.HtmlDecode(this._servDescription);
            }
            set
            {
                this._servDescription = value;
            }
        }
        public string SiteName
        {
            get
            {
                return this._siteName;
            }
            set
            {
                this._siteName = value;
            }
        }
        public DateTime ExpDate
        {
            get
            {
                if (this._expData == null)
                    this._expData = new DateTime();
                return this._expData;
            }
            set
            {
                this._expData = value;
            }
        }
        public DateTime LastUpdate
        {
            get
            {
                if (this._lastUpdate == null)
                    this._lastUpdate = new DateTime();
                return this._lastUpdate;
            }
            set
            {
                this._lastUpdate = value;
            }
        }
        public List<Procedure> Procedures
        {
            get
            {
                if (this._procedures == null)
                    this._procedures = new List<Procedure>();
                return this._procedures;
            }
            set
            {
                this._procedures = value;
            }
        }
        #endregion

        #region Helpers
        public string GetExpDateFormat
        {
            get
            {
                return this.ExpDate.ToShortDateString();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Unit Test Case #1 - generate an alert in case Expiration Dated is
        /// lower than current date
        /// </summary>
        public void IsExpired()
        {
            if (this.ExpDate < DateTime.Today)
            {
                throw new Exception("This case is already Expired");
            }
        }
        #endregion
    }
}