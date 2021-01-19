using System;
using Moq;
using NUnit.Framework;
using Twilio.Security;

namespace Christmas.API.Test.Adapter
{
    public class TwilioRequestValidator
    {
        [Test]
        public void ItMapsRequestsSuccessfully()
        {
            var mockValidator = new Mock<RequestValidator>();
            // pass this into the adapter when constructed.


        }
    }
}