﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFlow.Types
{
    public class Queries
    {
        public class SearchQuery
        {
            public DirectoryInfo directory { get; }
            public List<string> queries { get; }
            public bool subdirectories { get; }
            public SearchQuery(DirectoryInfo directory, List<string> queries, bool subdirectories)
            {
                this.directory = directory;
                this.queries = queries;
                this.subdirectories = subdirectories;
            }
            public SearchQuery(DirectoryInfo directory, string query, bool subdirectories)
            {
                this.directory = directory;
                queries = new List<string>
                {
                    query
                };
                this.subdirectories = subdirectories;
            }
        }
    }
}
