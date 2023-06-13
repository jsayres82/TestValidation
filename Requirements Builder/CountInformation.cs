using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Requirements_Builder
{
    class CountInformation
    {
        #region Properties

        /// <summary>
        /// Gets the ID associated with the count.
        /// </summary>
        public Int64 CountId { get; private set; }
        /// <summary>
        /// Gets the serial number of the cell.
        /// </summary>
        public UInt64 SerialNumber { get; private set; }
        /// <summary>
        /// Gets the location of the cell.
        /// </summary>
        public String Location { get; private set; }
        /// <summary>
        /// Gets the quantity of pills counted.
        /// </summary>
        public Int16 QuantityCounted { get; private set; }
        /// <summary>
        /// Gets the quantity of pills requested.
        /// </summary>
        public Int16 QuantityRequested { get; private set; }
        /// <summary>
        /// Gets the pill count rate in pills per second.
        /// </summary>
        public Double PillRate { get; private set; }
        /// <summary>
        /// Gets the number of jams that occurred during counting.
        /// </summary>
        public Byte JamCount { get; private set; }
        /// <summary>
        /// The data associated with this fill.
        /// </summary>
        public List<NameValuePair> Data { get; private set; }

        #endregion Properties

        #region Constructors

        public CountInformation()
        {
            //CountId = countStatus.CountId;
            //SerialNumber = countStatus.SerialNumber;
            //Location = countStatus.Location;
            //State = countStatus.State;
            //QuantityCounted = countStatus.QuantityCounted;
            //QuantityRequested = countStatus.QuantityRequested;
            //PillRate = countStatus.PillRate;
            //JamCount = countStatus.JamCount;
            //ErrorStatus = countStatus.ErrorStatus;

            //var context = (from p in countStatus.ContextInformation
            //               select new NameValuePair(p.Key, p.Value)).ToList();

            //var data = (from p in countStatus.PerformanceData
            //            select new NameValuePair(p.FullName, p.Value.ToString())).ToList();

            //Data = new List<NameValuePair>(context);
            //Data.AddRange(data);
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    struct NameValuePair
    {
        public String Name { get; set; }
        public String Value { get; set; }

        public NameValuePair(String name, String value)
            : this()
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}", Name, Value);
        }
    }
}
