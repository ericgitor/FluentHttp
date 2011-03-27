
namespace FluentHttp
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Base class for OAuth2 Authenticators.
    /// </summary>
    public abstract class OAuth2Authenticator : IFluentAuthenticator
    {
        /// <summary>
        /// The oauth_token
        /// </summary>
        private readonly string oauthToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuth2Authenticator"/> class.
        /// </summary>
        /// <param name="oauthToken">
        /// The oauth token.
        /// </param>
        [ContractVerification(true)]
        protected OAuth2Authenticator(string oauthToken)
        {
            Contract.Requires(!string.IsNullOrEmpty(oauthToken));

            this.oauthToken = oauthToken;
        }

        /// <summary>
        /// Gets the OAuth2 token.
        /// </summary>
        public string OAuthToken
        {
            get
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));
                return this.oauthToken;
            }
        }

        #region Implementation of IFluentAuthenticator

        /// <summary>
        /// Authenticate the fluent http request using OAuth2.
        /// </summary>
        /// <param name="fluentHttpRequest">
        /// The fluent http request.
        /// </param>
        public abstract void Authenticate(IFluentHttpRequest fluentHttpRequest);

        #endregion

        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
            Justification = "Reviewed. Suppression is OK here.")]
        [ContractInvariantMethod]
        private void InvariantObject()
        {
            Contract.Invariant(!string.IsNullOrEmpty(this.oauthToken));
        }
    }

    /// <summary>
    /// The OAuth 2 authenticator using the authorization request header field.
    /// </summary>
    /// <remarks>
    /// Based on http://tools.ietf.org/html/draft-ietf-oauth-v2-10#section-5.1.1
    /// </remarks>
    [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Reviewed. Suppression is OK here.")]
    public class OAuth2AuthorizationRequestHeaderAuthenticator : OAuth2Authenticator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuth2AuthorizationRequestHeaderAuthenticator"/> class.
        /// </summary>
        /// <param name="oauthToken">
        /// The oauth token.
        /// </param>
        public OAuth2AuthorizationRequestHeaderAuthenticator(string oauthToken)
            : base(oauthToken)
        {
            Contract.Requires(!string.IsNullOrEmpty(oauthToken));
        }

        #region Overrides of OAuth2Authenticator

        /// <summary>
        /// Authenticate the fluent http request using OAuth2 request header.
        /// </summary>
        /// <param name="fluentHttpRequest">
        /// The fluent http request.
        /// </param>
        [ContractVerification(true)]
        public override void Authenticate(IFluentHttpRequest fluentHttpRequest)
        {
            fluentHttpRequest.Headers(headers => headers.Add("Authorization", "OAuth " + OAuthToken));
        }

        #endregion
    }

    /// <summary>
    /// Authenticate the fluent http request using OAuth2 uri querystring parameter.
    /// </summary>
    public class OAuth2UriQueryParameterAuthenticator : OAuth2Authenticator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuth2UriQueryParameterAuthenticator"/> class.
        /// </summary>
        /// <param name="oauthToken">
        /// The oauth token.
        /// </param>
        public OAuth2UriQueryParameterAuthenticator(string oauthToken)
            : base(oauthToken)
        {
            Contract.Requires(!string.IsNullOrEmpty(oauthToken));
        }

        /// <summary>
        /// Authenticate the fluent http request using OAuth2 uri querystring parameter.
        /// </summary>
        /// <param name="fluentHttpRequest">
        /// The fluent http request.
        /// </param>
        public override void Authenticate(IFluentHttpRequest fluentHttpRequest)
        {
            fluentHttpRequest.QueryStrings(qs => qs.Add("oauth_token", this.OAuthToken));
        }
    }
}