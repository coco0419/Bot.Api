namespace Bot.Api.Common.Models
{
    using System;
    using System.Text.RegularExpressions;

    public class Polling<TResult>
    {
        private readonly Regex _regex;
        private readonly Func<Match, TResult> _action;

        public Polling(Regex regex, Func<Match, TResult> action)
        {
            _regex = regex;
            _action = action;
        }

        public Regex Regex => _regex;
        public Func<Match, TResult> Action => _action;
    }
}
