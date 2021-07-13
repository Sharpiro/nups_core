using System;
using System.IO;
using System.Linq;

namespace Nintenlord.UPSpatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string patch_path;
            string rom_path;
            if (args.Length == 2)
            {
                patch_path = args[0];
                rom_path = args[1];
            }
            else if (args.Length == 1)
            {
                patch_path = args[0];
                rom_path = $"{Path.GetFileNameWithoutExtension(patch_path)}.gba";
            }
            else
            {
                var upsFiles = Directory.GetFiles(".")
                    .Where(f => f.ToLowerInvariant().EndsWith(".ups"))
                    .ToList();
                
                if (upsFiles.Count == 0)
                {
                    Console.Error.WriteLine("Error: no .ups file detected");
                    Environment.Exit(1);
                }
                if (upsFiles.Count > 1)
                {
                    Console.Error.WriteLine("Error: more than 1 .ups file detected");
                    Environment.Exit(1);
                }

                patch_path = upsFiles[0];
                rom_path = $"{Path.GetFileNameWithoutExtension(patch_path)}.gba";
            }

            var patched_rom_path = $"{Path.GetFileNameWithoutExtension(rom_path)}_patched.gba";

            Console.WriteLine($"patch: {patch_path}");
            Console.WriteLine($"source rom: {rom_path}");
            Console.WriteLine($"dest rom: {patched_rom_path}");

            if (!File.Exists(patch_path)){
                Console.Error.WriteLine($"Error: patch '{patch_path}' not found");
                Environment.Exit(1);
            }

            if (!File.Exists(rom_path)){
                Console.Error.WriteLine($"Error: rom '{rom_path} not found");
                Environment.Exit(1);
            }

            try
            {
                var patchApplier = new PatchApplier();
                patchApplier.button2_Click(rom_path, patch_path, patched_rom_path);
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                Environment.Exit(1);
            }
        }
    }
}
