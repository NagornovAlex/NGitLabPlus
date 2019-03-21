﻿using System;
using System.Diagnostics;

namespace NGitLab.Impl {
    //[DebuggerStepThrough]
    public class Api {
        readonly string hostUrl;
        public readonly string ApiToken;
         internal     ApiVersion _ApiVersion { get; set; } = ApiVersion.V4_Oauth;
        public Api(string hostUrl, string apiToken, ApiVersion apiVersion):this(hostUrl,apiToken)
        {
            _ApiVersion = apiVersion;
        }
        public Api(string hostUrl, string apiToken) {
            this.hostUrl = hostUrl.EndsWith("/") ? hostUrl.Replace("/$", "") : hostUrl;
            ApiToken = apiToken;
        }

        public HttpRequestor Get() {
            return new HttpRequestor(this, MethodType.Get);
        }

        public HttpRequestor Post() {
            return new HttpRequestor(this, MethodType.Post);
        }

        public HttpRequestor Put() {
            return new HttpRequestor(this, MethodType.Put);
        }

        public HttpRequestor Delete() {
            return new HttpRequestor(this, MethodType.Delete);
        }

        public Uri GetApiUrl(string tailApiUrl) {
            if (!tailApiUrl.StartsWith("/"))
                tailApiUrl = "/" + tailApiUrl;
            return new Uri($"{hostUrl}{(hostUrl.EndsWith("/")?"":"/")}api/{(_ApiVersion.IsV3() ?"v3":"v4")}{tailApiUrl}");
        }

        public Uri GetUrl(string tailApiUrl) {
            if (!tailApiUrl.StartsWith("/"))
                tailApiUrl = "/" + tailApiUrl;

            return new Uri(hostUrl + tailApiUrl);
        }
    }
}