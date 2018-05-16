using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HereAPI.Routing.ResponseTypes
{

    /// <summary>
    /// Source attribution contains information that must be displayed in the user interface of applications using Routing API. 
    /// Source attributions are produced, for example, when route is using information available through certain public transportation 
    /// data providers. Attribution contains localized ready-to-display string with HTML markup as well as structured information that 
    /// could be used to get data without parsing attribution string. Source attribution contains as well additional information in form 
    /// of SourceSupplierNote - extra information which varies from supplier to supplier.
    /// </summary>
    public class SourceAttribution
    {

        /// <summary>
        /// Ready-to-display attribution string with HTML markup
        /// </summary>
        public string Attribution { get; set; }

        /// <summary>
        /// Structured information about source supplier.
        /// </summary>
        public SourceSupplier Supplier { get; set; }

        /// <summary>
        /// SourceSupplierType contains structured information about source data supplier. 
        /// </summary>
        public class SourceSupplier
        {
            /// <summary>
            /// Source data supplier title.
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// Link to source data supplier's website.
            /// </summary>
            public string Href { get; set; }
            /// <summary>
            /// Notes giving additional information about source data supplier.
            /// </summary>
            public SourceSupplierNote Note { get; set; }

            public enum SourceSupplierNoteType
            {
                [Description("ticketPurchase")] TicketPurchase,
                [Description("disclaimer")] Disclaimer
            }

            /// <summary>
            /// SourceSupplierNote contains information related specifically to data providers. 
            /// Informaiton consists of ready-to-display text and structured information if any is available. 
            /// </summary>
            public class SourceSupplierNote
            {
                /// <summary>
                /// Type of note.
                /// </summary>
                public SourceSupplierNoteType Type { get; set; }
                /// <summary>
                /// Ready-to-display note text. The text may contain HTML text and markup, including hyperlinks (i.e. &lt;a href&gt; elements).
                /// </summary>
                public string Text { get; set; }
                /// <summary>
                /// URL, to which note is referring, if any.
                /// </summary>
                public string Href { get; set; }
                /// <summary>
                /// Text, displayed with URL, to which note is referring, if any.
                /// </summary>
                public string Hreftext { get; set; }
            }

        }

    }
}
