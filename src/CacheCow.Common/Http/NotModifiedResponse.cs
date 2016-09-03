﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;

namespace CacheCow.Common.Http
{
	public class NotModifiedResponse : HttpResponseMessage
	{
        public NotModifiedResponse(HttpRequestMessage request, CacheControlHeaderValue cacheControlHeaderValue)
			: this(request, cacheControlHeaderValue, null)
		{
		}


		public NotModifiedResponse(HttpRequestMessage request, CacheControlHeaderValue cacheControlHeaderValue, EntityTagHeaderValue etag)
            :this(request, cacheControlHeaderValue, etag, null)

		{
		}

	    public NotModifiedResponse(HttpRequestMessage request, CacheControlHeaderValue cacheControlHeaderValue, EntityTagHeaderValue etag, TimeSpan? age)
            : base(HttpStatusCode.NotModified)
        {
            if (etag != null) this.Headers.ETag = etag;
            this.Headers.CacheControl = cacheControlHeaderValue;
            this.RequestMessage = request;
	        if (age != null) this.Headers.Age = age;
        }
	}


}
