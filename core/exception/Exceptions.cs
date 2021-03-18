
using System;

namespace clean_sharp {
    class AuthenticationException: Exception {

        public AuthenticationException() {

        }

    }

    class InternetConnectionException: Exception {

    }

    class HttpException: Exception
    {
        protected int code { get; set; }
        protected string message { get; set; }

        public HttpException(int code, string message) : base(message) {
            this.code = code;
            this.message = message;
        }

    }

    class GuardException: Exception {
        protected string message { get; set; }

        public GuardException(string message) : base(message) {
            this.message = message;
        }

    }
}