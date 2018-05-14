using HereAPI.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereAPI.Routing.ParameterTypes
{
    public class JsonRepresentation : IUrlParameter
    {

        public int JsonAttributesSum { get; set; }

        public JsonRepresentation(params JsonAttribute[] jsonAttributes)
        {
            foreach(JsonAttribute attr in jsonAttributes)
            {
                JsonAttributesSum += (int) attr;
            }
        }

        public string GetParameterName()
        {
            return "jsonAttributes";
        }

        public string GetParameterValue()
        {
            return $"{JsonAttributesSum}";
        }

        public enum JsonAttribute
        {
            LowerCaseFirstCharIdentifiers = 1,
            Include_TypeElement = 8,
            UsePluralNamingForCollections = 16,
            FlattenListOfShapesToDoubleArraysLatLon = 32,
            FlattenListOfShapesToDoubleArraysLatLonAlt = 64,
            SupressJsonResponseObjectWrapper = 128
        }
    }
}
