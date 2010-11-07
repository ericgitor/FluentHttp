﻿namespace FluentHttp
{
    using System;

    /// <summary>
    /// Fluent Http Wrapper
    /// </summary>
    public partial class FluentHttpRequest
    {
        /// <summary>
        /// Base url of the request.
        /// </summary>
        private readonly string _baseUrl;

        /// <summary>
        /// Name of the method
        /// </summary>
        private string _method;

        /// <summary>
        /// Timeout
        /// </summary>
        private int _timeout;

        private string _resourcePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentHttpRequest"/> class.
        /// </summary>
        /// <param name="baseUrl">
        /// The url to make request at.
        /// </param>
        public FluentHttpRequest(string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl))
                throw new ArgumentNullException("baseUrl");

            _baseUrl = baseUrl;
            _method = "GET";
        }

        /// <summary>
        /// Gets the base url to make request at.
        /// </summary>
        public string BaseUrl
        {
            get { return _baseUrl; }
        }

        /// <summary>
        /// Set resource path
        /// </summary>
        /// <param name="resourcePath">
        /// The resource path.
        /// </param>
        /// <returns>
        /// </returns>
        public FluentHttpRequest ResourcePath(string resourcePath)
        {
            if (!(string.IsNullOrEmpty(resourcePath) || (resourcePath = resourcePath.Trim()).Length == 0))
            {
                // if not null or empty
                if (resourcePath[0] != '/')
                {
                    // if doesn't start with / then add /
                    resourcePath = "/" + resourcePath;
                }
            }

            _resourcePath = resourcePath;
            return this;
        }

        /// <summary>
        /// Gets the resource path.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetResourcePath()
        {
            return _resourcePath;
        }

        /// <summary>
        /// Sets the http method.
        /// </summary>
        /// <param name="method">
        /// The http method.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Throws <see cref="ArgumentNullException"/> if method is null or empty.
        /// </exception>
        public FluentHttpRequest Method(string method)
        {
#if AGGRESSIVE_CHECK
            if (string.IsNullOrEmpty(method) || method.Trim().Length == 0)
                throw new ArgumentOutOfRangeException("method");
#endif

            _method = method;

            return this;
        }

        /// <summary>
        /// Gets the type of Http Method
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetMethod()
        {
            return _method;
        }

        /// <summary>
        /// Sets the timeout.
        /// </summary>
        /// <param name="timeout">
        /// The timeout.
        /// </param>
        /// <returns>
        /// </returns>
        public FluentHttpRequest Timeout(int timeout)
        {
            _timeout = timeout;
            return this;
        }

        /// <summary>
        /// Gets the timeout.
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetTimeout()
        {
            return _timeout;
        }

    }
}