//-----------------------------------------------------------------------
// <copyright file="TwitterStatus.cs" company="Patrick 'Ricky' Smith">
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
// <summary>The TwitterStatus class</summary>
//-----------------------------------------------------------------------
namespace Twitterizer
{
    using System;
    using System.Linq;
    using System.Diagnostics;
    using Newtonsoft.Json;
    using Twitterizer.Core;
    using Twitterizer.Entities;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;

    /// <include file='TwitterStatus.xml' path='TwitterStatus/TwitterStatus/*'/>
    [JsonObject(MemberSerialization.OptIn)]
#if !SILVERLIGHT
    [Serializable]
#endif
    [DebuggerDisplay("{User.ScreenName}/{Text}")]
    [DataContract]
    public class TwitterStatus : TwitterObject
    {
        #region Properties
        /// <summary>
        /// Gets or sets the status id.
        /// </summary>
        /// <value>The status id.</value>
        [DataMember, JsonProperty(PropertyName = "id")]
        public decimal Id { get; set; }

        /// <summary>
        /// Gets or sets the string id.
        /// </summary>
        /// <value>The string id.</value>
        [DataMember, JsonProperty(PropertyName = "id_str")]
        public string StringId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this status message is truncated.
        /// </summary>
        /// <value>
        /// <c>true</c> if this status message is truncated; otherwise, <c>false</c>.
        /// </value>
        [DataMember, JsonProperty(PropertyName = "truncated")]
        public bool? IsTruncated { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        [DataMember]
        [JsonProperty(PropertyName = "created_at")]
        [JsonConverter(typeof(TwitterizerDateConverter))]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        [DataMember, JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the screenName the status is in reply to.
        /// </summary>
        /// <value>The screenName.</value>
        [DataMember, JsonProperty(PropertyName = "in_reply_to_screen_name")]
        public string InReplyToScreenName { get; set; }

        /// <summary>
        /// Gets or sets the user id the status is in reply to.
        /// </summary>
        /// <value>The user id.</value>
        [DataMember, JsonProperty(PropertyName = "in_reply_to_user_id")]
        public decimal? InReplyToUserId { get; set; }

        /// <summary>
        /// Gets or sets the status id the status is in reply to.
        /// </summary>
        /// <value>The status id.</value>
        [DataMember, JsonProperty(PropertyName = "in_reply_to_status_id")]
        public decimal? InReplyToStatusId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the authenticated user has favorited this status.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is favorited; otherwise, <c>false</c>.
        /// </value>
        [DataMember, JsonProperty(PropertyName = "favorited")]
        public bool? IsFavorited { get; set; }

        /// <summary>
        /// Gets or sets the text of the status.
        /// </summary>
        /// <value>The status text.</value>
        [DataMember, JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this piece of content has been withheld due to a DMCA complaint.
        /// </summary>
        /// <value><c>true</c> if this piece of content has been withheld due to a DMCA complaint; otherwise, <c>false</c>.</value>
        [DataMember, JsonProperty(PropertyName = "withheld_copyright")]
        public bool WithheldCopyright { get; set; }

        /// <summary>
        /// Gets or sets the list of uppercase two-letter country codes this content is withheld from.
        /// </summary>
        /// <value>The list of countries the content is withheld.</value>
        [DataMember, JsonProperty(PropertyName = "withheld_in_countries")]
        public List<string> WithheldInCountries { get; set; }

        /// <summary>
        /// Gets or sets the withheld scope.
        /// </summary>
        /// <value>The withheld scope.</value>
        [DataMember, JsonProperty(PropertyName = "withheld_scope")]
        public string WithheldScope { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user that posted this status.</value>
        [DataMember, JsonProperty(PropertyName = "user")]
        public TwitterUser User { get; set; }

        /// <summary>
        /// Gets or sets the retweeted status.
        /// </summary>
        /// <value>The retweeted status.</value>
        [DataMember, JsonProperty(PropertyName = "retweeted_status")]
        public TwitterStatus RetweetedStatus { get; set; }

        /// <summary>
        /// Gets or sets the coordinates.
        /// </summary>
        /// <value>The coordinates.</value>
        [DataMember, JsonProperty(PropertyName = "coordinates")]
        public CoordinateCollection Coordinates { get; set; }

        /// <summary>
        /// Gets or sets the entities.
        /// </summary>
        /// <value>The entities.</value>
        [DataMember]
        [JsonProperty(PropertyName = "entities")]
        [JsonConverter(typeof(Entities.TwitterEntityCollection.Converter))]
        public Entities.TwitterEntityCollection Entities { get; set; }

        /// <summary>
        /// Gets or sets the contributors.
        /// </summary>
        /// <value>The contributors.</value>
        [DataMember, JsonProperty(PropertyName = "contributors")]
        public Collection<TwitterContributor> Contributors { get; set; }

        /// <summary>
        /// Gets or sets the retweet count string.
        /// </summary>
        /// <value>The retweet count.</value>
        [DataMember, JsonProperty(PropertyName = "retweet_count")]
        public int RetweetCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TwitterStatus"/> is retweeted.
        /// </summary>
        /// <value><c>true</c> if retweeted; otherwise, <c>false</c>.</value>
        [DataMember, JsonProperty(PropertyName = "retweeted")]
        public bool? Retweeted { get; set; }
        #endregion

        /// <summary>
        /// Returns the status text with HTML links to users, urls, and hashtags.
        /// </summary>
        /// <returns></returns>
        public string LinkifiedText()
        {
            return LinkifiedText(Entities, Text);
        }

        internal static string LinkifiedText(TwitterEntityCollection entities, string text)
        {
            if (entities == null || entities.Count == 0)
            {
                return text;
            }

            string linkedText = text;

            var entitiesSorted = entities.OrderBy(e => e.StartIndex).Reverse();

            foreach (TwitterEntity entity in entitiesSorted)
            {
                if (entity is TwitterHashTagEntity)
                {
                    TwitterHashTagEntity tagEntity = (TwitterHashTagEntity)entity;

                    linkedText = string.Format(
                        "{0}<a href=\"http://twitter.com/search?q=%23{1}\">{1}</a>{2}",
                        linkedText.Substring(0, entity.StartIndex),
                        tagEntity.Text,
                        linkedText.Substring(entity.EndIndex));
                }

                if (entity is TwitterUrlEntity)
                {
                    TwitterUrlEntity urlEntity = (TwitterUrlEntity)entity;

                    linkedText = string.Format(
                        "{0}<a href=\"{1}\">{1}</a>{2}",
                        linkedText.Substring(0, entity.StartIndex),
                        urlEntity.Url,
                        linkedText.Substring(entity.EndIndex));
                }

                if (entity is TwitterMentionEntity)
                {
                    TwitterMentionEntity mentionEntity = (TwitterMentionEntity)entity;

                    linkedText = string.Format(
                        "{0}<a href=\"http://twitter.com/{1}\">@{1}</a>{2}",
                        linkedText.Substring(0, entity.StartIndex),
                        mentionEntity.ScreenName,
                        linkedText.Substring(entity.EndIndex));
                }
            }

            return linkedText;
        }

        /// <summary>
        /// Updates the authenticating user's status. A status update with text identical to the authenticating user's text identical to the authenticating user's current status will be ignored to prevent duplicates.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="text">The status text.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// A <see cref="TwitterStatus"/> object of the newly created status.
        /// </returns>
        public async static Task<TwitterResponse<TwitterStatus>> Update(OAuthTokens tokens, string text, StatusUpdateOptions options = null)
        {
            return await CommandPerformer.PerformAction(new Commands.UpdateStatusCommand(tokens, text, options));
        }

		/// <summary>
		/// Updates the authenticating user's status. A status update with text identical to the authenticating user's text identical to the authenticating user's current status will be ignored to prevent duplicates.
		/// </summary>
		/// <param name="tokens">The tokens.</param>
		/// <param name="text">The status text.</param>
		/// <param name="fileData">The file to upload, as a byte array.</param>
		/// <param name="options">The options.</param>
		/// <returns>
		/// A <see cref="TwitterStatus"/> object of the newly created status.
		/// </returns>
		public async static Task<TwitterResponse<TwitterStatus>> UpdateWithMedia(OAuthTokens tokens, string text, byte[] fileData, StatusUpdateOptions options = null)
		{
            return await CommandPerformer.PerformAction(new Commands.UpdateWithMediaCommand(tokens, text, fileData, options));
		}

        /// <summary>
        /// Updates the authenticating user's status. A status update with text identical to the authenticating user's text identical to the authenticating user's current status will be ignored to prevent duplicates.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="text">The status text.</param>
        /// <param name="fileLocation">The file location.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// A <see cref="TwitterStatus"/> object of the newly created status.
        /// </returns>
        public async static Task<TwitterResponse<TwitterStatus>> UpdateWithMedia(OAuthTokens tokens, string text, string fileLocation, StatusUpdateOptions options = null)
        {
            return await UpdateWithMedia(tokens, text, System.IO.File.ReadAllBytes(fileLocation), options);
        }

        /// <summary>
        /// Deletes the specified status.
        /// </summary>
        /// <param name="tokens">The oauth tokens.</param>
        /// <param name="id">The status id.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// A <see cref="TwitterStatus"/> object of the deleted status.
        /// </returns>
        public async static Task<TwitterResponse<TwitterStatus>> Delete(OAuthTokens tokens, decimal id, OptionalProperties options = null)
        {
            Commands.DeleteStatusCommand command = new Twitterizer.Commands.DeleteStatusCommand(tokens, id, options);

            return await CommandPerformer.PerformAction(command);
        }

        /// <summary>
        /// Returns a single status, with user information, specified by the id parameter.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="statusId">The status id.</param>
        /// <param name="options">The options.</param>
        /// <returns>A <see cref="TwitterStatus"/> instance.</returns>
        public async static Task<TwitterResponse<TwitterStatus>> Show(decimal statusId, OAuthTokens tokens = null, OptionalProperties options = null)
        {
            return await CommandPerformer.PerformAction(new Commands.ShowStatusCommand(tokens, statusId, options));
        }

        /// <summary>
        /// Retweets a tweet. Requires the id parameter of the tweet you are retweeting. (say that 5 times fast)
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="statusId">The status id.</param>
        /// <param name="options">The options.</param>
        /// <returns>A <see cref="TwitterStatus"/> representing the newly created tweet.</returns>
        public async static Task<TwitterResponse<TwitterStatus>> Retweet(OAuthTokens tokens, decimal statusId, OptionalProperties options = null)
        {
            return await CommandPerformer.PerformAction(new Commands.RetweetCommand(tokens, statusId, options));
        }

        /// <summary>
        /// Returns up to 100 of the first retweets of a given tweet.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="statusId">The status id.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// A <see cref="TwitterStatusCollection"/> instance.
        /// </returns>
        public async static Task<TwitterResponse<TwitterStatusCollection>> Retweets(OAuthTokens tokens, decimal statusId, RetweetsOptions options = null)
        {
            return await CommandPerformer.PerformAction(new Commands.RetweetsCommand(tokens, statusId, options));
        }

        /// <summary>
        /// Retweets a tweet. Requires the id parameter of the tweet you are retweeting. (say that 5 times fast)
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// A <see cref="TwitterStatus"/> representing the newly created tweet.
        /// </returns>
        public async Task<TwitterResponse<TwitterStatus>> Retweet(OAuthTokens tokens, OptionalProperties options = null)
        {
            return await Retweet(tokens, this.Id, options);
        }
    }
}
