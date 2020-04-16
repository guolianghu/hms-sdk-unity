﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HuaweiMobileServices.Game
{
    using UnityEngine;
    using HuaweiMobileServices.Utils;
    using HuaweiMobileServices.Base;

    internal class ArchivesClientWrapper : JavaObjectWrapper, IArchivesClient
    {
        public ArchivesClientWrapper(AndroidJavaObject javaObject) : base(javaObject) { }

        public ITask<int> LimitThumbnailSize => CallAsWrapper<TaskPrimitive<int>>("getLimitThumbnailSize");

        public ITask<int> LimitDetailsSize => CallAsWrapper<TaskPrimitive<int>>("getLimitDetailsSize");

        public ITask<ArchiveSummary> AddArchive(ArchiveDetails paramArchiveDetails, ArchiveSummaryUpdate paramArchiveSummaryUpdate, bool paramBoolean) =>
            CallAsWrapper<TaskJavaObjectWrapper<ArchiveSummary>>("addArchive", paramArchiveDetails, paramArchiveSummaryUpdate, paramBoolean);

        public ITask<IList<ArchiveSummary>> GetArchiveSummaryList(bool paramBoolean)
        {
            var task = Call<AndroidJavaObject>("getArchiveSummaryList", paramBoolean);
            return new TaskWrapper<IList<ArchiveSummary>>(task, AndroidJavaObjectExtensions.AsListFromWrappable<ArchiveSummary>);
        }

        public ITask<AndroidIntent> GetShowArchiveListIntent(string paramString, bool paramBoolean1, bool paramBoolean2, int paramInt) =>
            CallAsWrapper<TaskJavaObjectWrapper<AndroidIntent>>("getShowArchiveListIntent", paramString, paramBoolean1, paramBoolean2, paramInt);

        public ITask<AndroidBitmap> GetThumbnail(string paramString) =>
            CallAsWrapper<TaskJavaObjectWrapper<AndroidBitmap>>("getThumbnail", paramString);

        public ITask<OperationResult> LoadArchiveDetails(ArchiveSummary paramArchiveSummary) =>
            CallAsWrapper<TaskJavaObjectWrapper<OperationResult>>("loadArchiveDetails", paramArchiveSummary);

        public ITask<OperationResult> LoadArchiveDetails(ArchiveSummary paramArchiveSummary, int paramInt) =>
            CallAsWrapper<TaskJavaObjectWrapper<OperationResult>>("loadArchiveDetails", paramArchiveSummary, paramInt);

        public ITask<OperationResult> LoadArchiveDetails(string paramString, int paramInt) =>
            CallAsWrapper<TaskJavaObjectWrapper<OperationResult>>("loadArchiveDetails", paramString, paramInt);

        public ITask<OperationResult> LoadArchiveDetails(string paramString) =>
            CallAsWrapper<TaskJavaObjectWrapper<OperationResult>>("loadArchiveDetails", paramString);

        public ITask<ArchiveSummary> ParseSummary(AndroidBundle paramBundle) =>
            CallAsWrapper<TaskJavaObjectWrapper<ArchiveSummary>>("parseSummary", paramBundle);

        public ITask<string> RemoveArchive(ArchiveSummary paramArchiveSummary) => CallAsWrapper<TaskStringWrapper>("removeArchive", paramArchiveSummary);

        public ITask<OperationResult> UpdateArchive(string paramString, ArchiveSummaryUpdate paramArchiveSummaryUpdate, ArchiveDetails paramArchiveDetails) =>
            CallAsWrapper<TaskJavaObjectWrapper<OperationResult>>("updateArchive", paramString, paramArchiveSummaryUpdate, paramArchiveDetails);

        public ITask<OperationResult> UpdateArchive(Archive paramArchive) =>
            CallAsWrapper<TaskJavaObjectWrapper<OperationResult>>("updateArchive", paramArchive);
    }
}