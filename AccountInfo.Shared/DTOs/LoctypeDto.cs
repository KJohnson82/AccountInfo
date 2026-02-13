using AccountInfo.Shared.Enums;

namespace AccountInfo.Shared.DTOs
{
    public class LoctypeDto
    {
        public int Id { get; set; }

        public string LoctypeName { get; set; } = string.Empty;

        public static List<LoctypeDto> GetLoctype()
        {
            return Enum.GetValues(typeof(Loctype))
                .Cast<Loctype>()
                .Select(e => new LoctypeDto
                {
                    Id = (int)e,
                    LoctypeName = e.ToString()
                })
                .ToList();
        }
    }
}
