using Terraria.ModLoader.IO;

namespace MatterOverdrive.Players
{
    public sealed partial class MOPlayer
    {
        public override TagCompound Save()
        {
            TagCompound tagCompound = new TagCompound()
            {
                { nameof(Android), Android }
            };

            return tagCompound;
        }

        public override void Load(TagCompound tag)
        {
            base.Load(tag);

            Android = tag.GetBool(nameof(Android));
        }
    }
}
