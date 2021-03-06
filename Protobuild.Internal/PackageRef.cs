﻿using System;

namespace Protobuild
{
    public struct PackageRef
    {
        public string Uri { get; set; }

        public string GitRef { get; set; }

        public string Folder { get; set; }

        public Uri UriObject
        {
            get
            {
                return new Uri(this.Uri);
            }
        }

        public bool Valid
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Uri))
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(this.Folder))
                {
                    return false;
                }

                if (this.Folder.Contains("/") || this.Folder.Contains("\\"))
                {
                    return false;
                }

                var scheme = this.UriObject.Scheme.ToLowerInvariant();

                if (scheme != "http" && scheme != "https")
                {
                    return false;
                }

                return true;
            }
        }
    }
}

