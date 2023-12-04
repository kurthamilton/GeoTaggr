namespace GeoTaggr.Web.Components.Shared.Forms.Selects
{
    public class SelectOption(string key, string text)
    {
        public string Key { get; set; } = key;

        public string Text { get; set; } = text;

        public override int GetHashCode() => Text.GetHashCode();

        public override string ToString() => Text;
    }
}
