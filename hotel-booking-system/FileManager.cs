namespace hotel_booking_system
{
    public static class FileManager
    {
        public static void Add(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (!entity.IsValid())
            {
                throw new Exception("Entity is invalid");
            }
            var record = entity.Format();
            using (var writer = new StreamWriter(entity.FileName, append: true))
            {
                writer.WriteLine(record);
            }
        }
        public static IEnumerable<T> GetEntities<T>(string path) where T : IEntity, new()
        {
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var entity = new T();
                entity.Parse(line);
                yield return entity;
            }
        }
    }
}
