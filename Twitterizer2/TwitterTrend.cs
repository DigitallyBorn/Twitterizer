//-----------------------------------------------------------------------
// <copyright file="TwitterTrend.cs" company="Patrick 'Ricky' Smith">
//  This file is part of the Twitterizer library (http://www.twitterizer.net/)
// 
//  Copyright (c) 2010, Patrick "Ricky" Smith (ricky@digitally-born.com)
//  All rights reserved.
//  
//  Redistribution and use in source and binary forms, with or without modification, are 
//  permitted provided that the following conditions are met:
// 
//  - Redistributions of source code must retain the above copyright notice, this list 
//    of conditions and the following disclaimer.
//  - Redistributions in binary form must reproduce the above copyright notice, this list 
//    of conditions and the following disclaimer in the documentation and/or other 
//    materials provided with the distribution.
//  - Neither the name of the Twitterizer nor the names of its contributors may be 
//    used to endorse or promote products derived from this software without specific 
//    prior written permission.
// 
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
//  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
//  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
//  IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
//  INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
//  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
//  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
//  WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
//  ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
//  POSSIBILITY OF SUCH DAMAGE.
// </copyright>
// <author>Ricky Smith</author>
// <summary>The Twitter Trend class</summary>
//-----------------------------------------------------------------------

namespace Twitterizer
{
    using System;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;
    using Twitterizer.Core;

    /// <summary>
    /// The TwitterTrend class.
    /// </summary>
#if !SILVERLIGHT
    [Serializable]
#endif
    [DataContract]
    public class TwitterTrend : TwitterObject
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name of the trend.</value>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the search query.
        /// </summary>
        /// <value>The search query.</value>
        [DataMember]
        public string SearchQuery { get; set; }

        /// <summary>
        /// Gets or sets the promoted content value.
        /// </summary>
        /// <value>Promoted Content.</value>
        [DataMember]
        public string PromotedContent { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>The events.</value>
        [DataMember]
        public string Events { get; set; }

        /// <summary>
        /// Gets the trends with the specified WOEID.
        /// </summary>
        /// <param name="tokens">The request tokens.</param>
        /// <param name="WoeID">The WOEID.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// A collection of <see cref="Twitterizer.TwitterTrend"/> objects.
        /// </returns>
        public async static Task<TwitterResponse<TwitterTrendCollection>> Trends(int WoeID, OAuthTokens tokens = null, LocalTrendsOptions options = null)
        {
            Commands.TrendsCommand command = new Twitterizer.Commands.TrendsCommand(tokens, WoeID, options);

            return await Core.CommandPerformer.PerformAction(command);
        }

        /// <summary>
        /// Gets the locations where trends are available.
        /// </summary>   
        /// <param name="tokens">The request tokens.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// A collection of <see cref="Twitterizer.TwitterTrendLocation"/> objects.
        /// </returns>
        public async static Task<TwitterResponse<TwitterTrendLocationCollection>> Available(OAuthTokens tokens = null, AvailableTrendsOptions options = null)
        {
            Commands.AvailableTrendsCommand command = new Twitterizer.Commands.AvailableTrendsCommand(tokens, options);

            return await Core.CommandPerformer.PerformAction(command);
        }

        /// <summary>
        /// Gets the daily global trends
        /// </summary>
        /// <param name="tokens">The request tokens.</param>
        /// <param name="options">The options.</param>
        public async static Task<TwitterResponse<TwitterTrendDictionary>> Daily(OAuthTokens tokens = null, TrendsOptions options = null)
        {
            Commands.DailyTrendsCommand command = new Twitterizer.Commands.DailyTrendsCommand(tokens, options);

            return await Core.CommandPerformer.PerformAction(command);
        }

        /// <summary>
        /// Gets the weekly global trends
        /// </summary>
        /// <param name="tokens">The request tokens.</param>
        /// <param name="options">The options.</param>
        public async static Task<TwitterResponse<TwitterTrendDictionary>> Weekly(OAuthTokens tokens = null, TrendsOptions options = null)
        {
            Commands.WeeklyTrendsCommand command = new Twitterizer.Commands.WeeklyTrendsCommand(tokens, options);

            return await Core.CommandPerformer.PerformAction(command);
        }
    }
}
