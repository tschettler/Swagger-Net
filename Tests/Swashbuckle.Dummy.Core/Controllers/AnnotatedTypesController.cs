﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace Swashbuckle.Dummy.Controllers
{
    public class AnnotatedTypesController : ApiController
    {
        public int Create(Payment payment)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));

            throw new NotImplementedException();
        }
    }

    public class Payment
    {
        [Required]
        public decimal Amount { get; set; }

        [Required, RegularExpression("^[3-6]?\\d{12,15}$")]
        public string CardNumber { get; set; }

        /// <summary>Credit card expiration Month</summary>
        /// <example>6</example>
        [Required, Range(1, 12)]
        public int ExpMonth { get; set; }

        /// <summary>Credit card expiration Year</summary>
        /// <example>96</example>
        [Required, Range(14, 99)]
        public int ExpYear { get; set; }

        [StringLength(500, MinimumLength = 10)]
        public string Note { get; set; }
    }
}