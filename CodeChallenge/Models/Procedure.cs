namespace CodeChallenge.Models
{
    public class Procedure
    {
        #region Data Members
        private int _id;
        private string _desc;
        private int _qtyRequested;
        private int _qtyApproved;
        private string _modifiers;
        #endregion

        #region Contructor
        public Procedure()
        {}
        public Procedure(int id, string desc, int qtyRequested, int qtyApproved, string modifiers)
        {
            Id = id;
            Desc = desc;
            QtyRequested = qtyRequested;
            QtyApproved = qtyApproved;
            Modifiers = modifiers;
        }
        #endregion

        #region Properties
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        public string Desc
        {
            get
            {
                return this._desc;
            }
            set
            {
                this._desc = value;
            }
        }
        public int QtyRequested
        {
            get
            {
                return this._qtyRequested;
            }
            set
            {
                this._qtyRequested = value;
            }
        }
        public int QtyApproved
        {
            get
            {
                return this._qtyApproved;
            }
            set
            {
                this._qtyApproved = value;
            }
        }
        public string Modifiers
        {
            get
            {
                return this._modifiers;
            }
            set
            {
                this._modifiers = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Unit Test Case #2 - generate an alert in case requested quantity is lower
        /// than approved quantity
        /// </summary>
        public void QtyOutofRequested()
        {
            if (this.QtyApproved < this.QtyRequested)
                throw new System.Exception("Quantity approved is less than quantity requested");
        }

        /// <summary>
        /// Unit Test Case #3 - generate an alert in case requested quantity is 0
        /// or lower
        /// </summary>
        public void QtyRequestedZero()
        {
            if (this.QtyRequested == 0)
                throw new System.Exception("Requested quantity is 0");

            if(this.QtyRequested < 0)
                throw new System.ArgumentOutOfRangeException("Requested quantity has a invalid number");

        }
        #endregion
    }
}