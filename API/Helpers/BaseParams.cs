﻿using System;

namespace API.Helpers
{
    public class BaseParams
    {
        private const int MaxSize = 25;

        private int _pageNumber = 1;
        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = value <= 0 ? 1 : value;
        }

        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set
            {
                _pageSize = value switch
                {
                    > MaxSize => MaxSize,
                    <= 0 => 10,
                    _ => value
                };
                SetTotalPages();
            }
        }

        public int TotalPages { get; set; }

        private int _totalCount;
        public int TotalCount
        {
            get => _totalCount;
            set
            {
                _totalCount = value;
                SetTotalPages();
            }
        }

        public string OrderBy { get; set; }

        private void SetTotalPages()
        {
            if (_totalCount <= 0) return;
            TotalPages = (int)Math.Ceiling(_totalCount / (decimal)_pageSize);
        }
    }
}