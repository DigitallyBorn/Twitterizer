//-----------------------------------------------------------------------
// <copyright file="TwitterTimeline.cs" company="Patrick 'Ricky' Smith">
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
// <summary>The TwitterTimeline class</summary>
//-----------------------------------------------------------------------

namespace Twitterizer
{
    using System;
    using System.Threading.Tasks;
    using Twitterizer.Core;

    /// <summary>
    /// Provides interaction with timelines
    /// </summary>
    public static class TwitterTimeline
    {
        /// <overloads>
        /// Returns the 20 most recent statuses, including retweets, posted by the authenticating user and that user's friends. This is the equivalent of /timeline/home on the Web.
        /// </overloads>
        /// <param name="tokens">The tokens.</param>
        /// <param name="options">The options.</param>
        /// <returns>A collection of <see cref="TwitterStatus"/> items.</returns>
        public async static Task<TwitterResponse<TwitterStatusCollection>> HomeTimeline(OAuthTokens tokens = null, TimelineOptions options = null)
        {
            Commands.HomeTimelineCommand command = new Commands.HomeTimelineCommand(tokens, options);

            return await Core.CommandPerformer.PerformAction(command);
        }

        /// <summary>
        /// Returns the 20 most recent statuses posted by the authenticating user. It is also possible to request another user's timeline by using the screen_name or user_id parameter.
        /// </summary>
        /// <param name="tokens">The oauth tokens.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// A <see cref="TwitterStatusCollection"/> instance.
        /// </returns>
        public async static Task<TwitterResponse<TwitterStatusCollection>> UserTimeline(
            OAuthTokens tokens = null,
            UserTimelineOptions options = null)
        {
            Commands.UserTimelineCommand command = new Commands.UserTimelineCommand(tokens, options);

            return await Core.CommandPerformer.PerformAction(command);
        }

        /// <summary>
        /// Returns the 20 most recent tweets of the authenticated user that have been retweeted by others.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="options">The options.</param>
        /// <returns>A <see cref="TwitterStatusCollection"/> instance.</returns>
        public async static Task<TwitterResponse<TwitterStatusCollection>> RetweetsOfMe(OAuthTokens tokens, RetweetsOfMeOptions options = null)
        {
            return await CommandPerformer.PerformAction(
                new Commands.RetweetsOfMeCommand(tokens, options));
        }

        /// <summary>
        /// Returns the 20 most recent mentions (status containing @username) for the authenticating user.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="options">The options.</param>
        /// <returns>A <see cref="TwitterStatusCollection"/> instance.</returns>
        public async static Task<TwitterResponse<TwitterStatusCollection>> Mentions(OAuthTokens tokens, TimelineOptions options = null)
        {
            Commands.MentionsCommand command = new Commands.MentionsCommand(tokens, options);
            return await CommandPerformer.PerformAction(command);
        }
    }
}
