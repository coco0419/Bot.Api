namespace Bot.Api.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Bot<TResult>
    {
        private readonly Queue<Polling<TResult>> _pollings;
        private readonly string _text;

        public Bot(string text)
        {
            _pollings = new Queue<Polling<TResult>>();
            _text = text;
        }

        public Bot<TResult> Polling(Regex regex, Func<Match, TResult> action)
        {
            _pollings.Enqueue(new Polling<TResult>(regex, action));

            return this;
        }

        public TResult Execute(Func<TResult> otherAction)
        {
            var result = _pollings.Where(x => x.Regex.IsMatch(_text)).Select(x => x.Action.Invoke(x.Regex.Match(_text))).ToArray();

            return result.Length > 0 ? result.First() : otherAction.Invoke();
        }
    }
}
