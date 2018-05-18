using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using HereAPI.Shared.Structure;

namespace HereAPI.Shared.Requests
{
    /// <summary>
    /// This class means to isolate the logic to validate the service request
    /// and avoid bloating the ServieRequest class
    /// </summary>
    public class HereApiRequestValidation
    {
        private List<string> Errors;
        private HereApiServiceRequest Request;

        public HereApiRequestValidation(HereApiServiceRequest request)
        {
            Request = request;
        }

        public string[] GetValidationErrors()
        {
            Validate();
            return Errors.ToArray();
        }

        public void Validate()
        {
            Errors = new List<string>();

            var attrValErrors = AttributeValidator.Validate(Request);
            if (attrValErrors.Length > 0)
            {
                Errors.AddRange(attrValErrors);
                return;
            }

            Errors.AddRange(Request.ValidateConditionalAttributes());
        }

        public bool IsValid()
        {
            Validate();
            return Errors.Count == 0;
        }

    }
}
