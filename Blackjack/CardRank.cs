using System.Collections.Generic;
using System.ComponentModel;

namespace Blackjack
{
    public enum CardRank
    {
        [Description("Ace")]
        Ace = 1,
        [Description("2")]
        Two,
        [Description("3")]
        Three,
        [Description("4")]
        Four,
        [Description("5")]
        Five,
        [Description("6")]
        Six,
        [Description("7")]
        Seven,
        [Description("8")]
        Eight,
        [Description("9")]
        Nine,
        [Description("10")]
        Ten,
        [Description("Jack")]
        Jack,
        [Description("Queen")]
        Queen,
        [Description("King")]
        King
    }
}
