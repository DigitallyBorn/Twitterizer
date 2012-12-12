//-----------------------------------------------------------------------
// <copyright file="TwitterFriendship.cs" company="Patrick 'Ricky' Smith">
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
// <summary>The TwitterFriendship class.</summary>
//-----------------------------------------------------------------------

namespace Twitterizer
{
    using Core;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides interaction with the Twitter API to obtain and manage relationships between users.
    /// </summary>
    public static class TwitterFriendship
    {
        /// <summary>
        /// Returns the authenticating user's followers, each with current status inline.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// A <see cref="TwitterStatusCollection"/> instance.
        /// </returns>
        public async static Task<TwitterResponse<TwitterUserCollection>> Followers(OAuthTokens tokens, FollowersOptions options = null)
        {
            Commands.FollowersCommand command = new Commands.FollowersCommand(tokens, options);

            return await CommandPerformer.PerformAction(command);
        }

        /// <summary>
        /// Returns a user's friends, each with current status inline. They are ordered by the order in which the user followed them, most recently followed first, 100 at a time.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// A <see cref="TwitterUserCollection"/> instance.
        /// </returns>
        /// <remarks>Please note that the result set isn't guaranteed to be 100 every time as suspended users will be filtered out.</remarks>
        [System.Obsolete("This method is deprecated as it will only return information about users who have Tweeted recently. It is not a functional way to retrieve all of a users friends. Instead of using this method use a combination of friends/ids and users/lookup.")]
        public async static Task<TwitterResponse<TwitterUserCollection>> Friends(OAuthTokens tokens, FriendsOptions options = null)
        {
            Commands.FriendsCommand command = new Commands.FriendsCommand(tokens, options);

            return await CommandPerformer.PerformAction(command);
        }


        /// <summary>
        /// Allows the authenticating users to follow the user specified in the userID parameter.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// Returns the followed user in the requested format when successful.
        /// </returns>
        public async static Task<TwitterResponse<TwitterUser>> Create(OAuthTokens tokens, decimal userId, CreateFriendshipOptions options = null)
        {
            Commands.CreateFriendshipCommand command = new Commands.CreateFriendshipCommand(tokens, userId, options);
            return await CommandPerformer.PerformAction(command);
        }

        /// <summary>
        /// Allows the authenticating users to follow the user specified in the userName parameter.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="userName">The user name.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// Returns the followed user in the requested format when successful.
        /// </returns>
        public async static Task<TwitterResponse<TwitterUser>> Create(OAuthTokens tokens, string userName, CreateFriendshipOptions options = null)
        {
            Commands.CreateFriendshipCommand command = new Commands.CreateFriendshipCommand(tokens, userName, options);
            return await CommandPerformer.PerformAction(command);
        }

        
        /// <summary>
        /// Allows the authenticating users to unfollow the user specified in the ID parameter.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// Returns the unfollowed user in the requested format when successful.
        /// </returns>
        public async static Task<TwitterResponse<TwitterUser>> Delete(OAuthTokens tokens, decimal userId, OptionalProperties options = null)
        {
            Commands.DeleteFriendshipCommand command = new Commands.DeleteFriendshipCommand(tokens, userId, string.Empty, options);
            return await CommandPerformer.PerformAction(command);
        }

        /// <summary>
        /// Allows the authenticating users to unfollow the user specified in the ID parameter.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="userName">The username.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// Returns the unfollowed user in the requested format when successful.
        /// </returns>
        public async static Task<TwitterResponse<TwitterUser>> Delete(OAuthTokens tokens, string userName, OptionalProperties options = null)
        {
            Commands.DeleteFriendshipCommand command = new Commands.DeleteFriendshipCommand(tokens, 0, userName, options);
            return await Core.CommandPerformer.PerformAction(command);
        }

        /// <summary>
        /// Returns detailed information about the relationship between two users.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="sourceUseId">The source user id.</param>
        /// <param name="targetUserId">The target user id.</param>
        /// <param name="options">The options.</param>
        /// <returns>A <see cref="TwitterRelationship"/> instance.</returns>
        public async static Task<TwitterResponse<TwitterRelationship>> Show(OAuthTokens tokens, decimal sourceUseId = 0, decimal targetUserId = 0, OptionalProperties options = null)
        {
            Commands.ShowFriendshipCommand command = new Twitterizer.Commands.ShowFriendshipCommand(
                tokens, 
                sourceUseId, 
                string.Empty, 
                targetUserId, 
                string.Empty, 
                options);

            return await Core.CommandPerformer.PerformAction(command);
        }

        /// <summary>
        /// Returns detailed information about the relationship between two users.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="sourceUserName">The source user name.</param>
        /// <param name="targetUserName">The target user name.</param>
        /// <param name="options">The options.</param>
        /// <returns>A <see cref="TwitterRelationship"/> instance.</returns>
        public async static Task<TwitterResponse<TwitterRelationship>> Show(OAuthTokens tokens, string sourceUserName = "", string targetUserName = "", OptionalProperties options = null)
        {
            Commands.ShowFriendshipCommand command = new Twitterizer.Commands.ShowFriendshipCommand(tokens, 0, sourceUserName, 0, targetUserName, options);

            return await Core.CommandPerformer.PerformAction(command);
        }

        /// <summary>
        /// Returns the numeric IDs for every user the specified user is friends with.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// A <see cref="TwitterListCollection"/> instance.
        /// </returns>
        public async static Task<TwitterResponse<UserIdCollection>> FriendsIds(OAuthTokens tokens, UsersIdsOptions options = null)
        {
            Commands.FriendsIdsCommand command = new Commands.FriendsIdsCommand(tokens, options);
            return await Core.CommandPerformer.PerformAction(command);
        }

        /// <summary>
        /// Returns the numeric IDs for every user the specified user is following.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// A <see cref="TwitterListCollection"/> instance.
        /// </returns>
        public async static Task<TwitterResponse<UserIdCollection>> FollowersIds(OAuthTokens tokens, UsersIdsOptions options = null)
        {
            Commands.FollowersIdsCommand command = new Commands.FollowersIdsCommand(tokens, options);
            return await Core.CommandPerformer.PerformAction(command);
        }

        /// <summary>
        /// Returns a collection of IDs for every user who has a pending request to follow the authenticating user.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public async static Task<TwitterResponse<TwitterCursorPagedIdCollection>> IncomingRequests(OAuthTokens tokens, IncomingFriendshipsOptions options = null)
        {
            Commands.IncomingFriendshipsCommand command = new Commands.IncomingFriendshipsCommand(tokens, options);
            return await Core.CommandPerformer.PerformAction(command);
        }

        /// <summary>
        /// Returns a collection of IDs for every protected user for whom the authenticating user has a pending follow request.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public async static Task<TwitterResponse<TwitterCursorPagedIdCollection>> OutgoingRequests(OAuthTokens tokens, OutgoingFriendshipsOptions options = null)
        {
            Commands.OutgoingFriendshipsCommand command = new Commands.OutgoingFriendshipsCommand(tokens, options);
            return await Core.CommandPerformer.PerformAction(command);
        }

        /// <summary>
        /// Returns a collection of IDs that the user does not want to see retweets from.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public async static Task<TwitterResponse<UserIdCollection>> NoRetweetIDs(OAuthTokens tokens, OptionalProperties options = null)
        {
            Commands.NoRetweetIDsCommand command = new Commands.NoRetweetIDsCommand(tokens, options);
            return await Core.CommandPerformer.PerformAction(command);
        }


        /// <summary>
        /// Updates a friendship for a user.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="userid">The userid.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public async static Task<TwitterResponse<TwitterRelationship>> Update(OAuthTokens tokens, decimal userid, UpdateFriendshipOptions options = null)
        {
            Commands.UpdateFriendshipCommand command = new Commands.UpdateFriendshipCommand(tokens, userid, options);
            return await Core.CommandPerformer.PerformAction(command);
        }

        /// <summary>
        /// Updates a friendship for a user.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="screenname">The screenname.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public async static Task<TwitterResponse<TwitterRelationship>> Update(OAuthTokens tokens, string screenname, UpdateFriendshipOptions options = null)
        {
            Commands.UpdateFriendshipCommand command = new Commands.UpdateFriendshipCommand(tokens, screenname, options);
            return await Core.CommandPerformer.PerformAction(command);
        }
    }
}
