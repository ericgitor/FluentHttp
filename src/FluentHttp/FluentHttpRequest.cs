﻿namespace FluentHttp
{
    using System;
    using System.ComponentModel;
    using System.Net;

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

        /// <summary>
        /// Resource Path
        /// </summary>
        private string _resourcePath;

        /// <summary>
        /// Decompression Methods
        /// </summary>
        private DecompressionMethods _decompressionMethods = System.Net.DecompressionMethods.Deflate |
                                                             System.Net.DecompressionMethods.GZip |
                                                             System.Net.DecompressionMethods.None;

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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetTimeout()
        {
            return _timeout;
        }

        /// <summary>
        /// Sets the decompression methods.
        /// </summary>
        /// <param name="decompressionMethods">
        /// The decompression methods.
        /// </param>
        /// <returns>
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FluentHttpRequest DecompressionMethods(DecompressionMethods decompressionMethods)
        {
            _decompressionMethods = decompressionMethods;
            return this;
        }

        /// <summary>
        /// Gets the decompression methods.
        /// </summary>
        /// <returns>
        /// Returns the decompression methods.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DecompressionMethods GetDecompressionMethods()
        {
            return _decompressionMethods;
        }

        #region Hide defualt object methods

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

#pragma warning disable 0108
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Type GetType()
        {
            return base.GetType();
        }
#pragma warning restore 0108

        #endregion

    }
}