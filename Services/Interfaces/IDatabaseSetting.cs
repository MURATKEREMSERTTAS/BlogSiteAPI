namespace BlogSiteAPI.Interfaces
{
    public interface IDatabaseSetting
    {
        public string DatabaseName { get; set; }

        public string ConnectionString { get; set; }

        public string UserCollectionName { get; set; }
        public string ContentCollectionName { get; set; }
        public string CommentCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string TagCollectionName { get; set; }
        public string AuthorCollectionName { get; set; }
    }
}
