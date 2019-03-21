﻿using NGitLab.Models;

namespace NGitLab {
    public interface IFilesClient {
        void Create(FileUpsert file);
        void Update(FileUpsert file);
        void Delete(FileDelete file);
        FileData Get(string filePath, string branch = "", System.Action<System.IO.Stream> parser = null);
    }
}