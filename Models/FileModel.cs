using Microsoft.AspNetCore.Mvc;
using System;

namespace ABCretail2.Models
{
    public class FileModel
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public DateTimeOffset LastModified { get; set; }
    }
}
