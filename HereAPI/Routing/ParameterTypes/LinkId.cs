using HereAPI.Shared;
using HereAPI.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HereAPI.Routing.ParameterTypes
{
    public class LinkId
    {

        public enum LinkDirection
        {
            [Description("+")] To,
            [Description("-")] From,
            [Description("*")] Any
        }

        public int Id { get; set; }
        public LinkDirection Direction { get; set; }


        public LinkId(int linkID, LinkDirection linkDirection)
        {
            Id = linkID;
            Direction = linkDirection;
        }

        public string GetParameterValue()
        {
            return $"{EnumHelper.GetDescription(Direction)}{Id}";
        }

    }
}
