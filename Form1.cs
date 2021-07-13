using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;

namespace Nintenlord.UPSpatcher
{
    public partial class PatchApplier
    {
        public PromptStyle prompt_style = PromptStyle.Notify;


        // select rom
        private void button3_Click()
        {
        }

        // select .ups patch
        private void button5_Click()
        {
        }

        // patch file
        public void button2_Click(string rom_path, string patch_path, string patched_rom_path)
        {
            UPSfile upsFile = new UPSfile(patch_path);
            byte[] file = null;

            try
            {
                BinaryReader br = new BinaryReader(File.Open(rom_path, FileMode.OpenOrCreate));
                file = br.ReadBytes((int)br.BaseStream.Length);
                br.Close();
            }
            catch (Exception)
            {
                throw new Exception("Error opening file\n" + rom_path);
            }

            if (!upsFile.ValidPatch)
            {
                throw new Exception("The patch is corrupt.");
            }

            bool validToApply = upsFile.ValidToApply(file);

            if (prompt_style == PromptStyle.Abort)
            {
                if (!validToApply)
                {
                    throw new Exception("The patch doesn't match the file.\nPatching canceled.");
                }
            }
            else if (prompt_style == PromptStyle.Ask)
            {
                if (!validToApply)
                {
                    throw new Exception("The patch doesn't match the file.\nPatching canceled.");
                }
            }
            else if (prompt_style == PromptStyle.Notify)
            {
                if (!validToApply)
                {
                    Console.WriteLine("The patch doesn't match the file.\nPatching anyway.");
                }
            }
            else if (prompt_style != PromptStyle.Ignore)
            {
                throw new Exception("What do you want me to do!?!?!?");
            }                

            byte[] newFile = upsFile.Apply(file);

            try
            {
                File.WriteAllBytes(patched_rom_path, newFile);
            }
            catch (Exception)
            {
                throw new Exception("Error writing patch");
            }

            Console.WriteLine("Patching has been done.");
        }

        // close window
        private void button1_Click()
        {
        }
    }

    public enum PromptStyle
    {
        Abort,
        Ask,
        Notify,
        Ignore
    }
}
