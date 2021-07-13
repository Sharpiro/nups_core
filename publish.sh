set -e

version="1.0.0"
targets=("linux-x64" "osx-x64")

mkdir -p publish
rm -f publish/*
rm -rf bin
rm -rf obj

for target in ${targets[@]}; do
  echo "building $target"
  file_name="nups_patcher_${target}_$version.zip"
  dotnet publish -r $target
  zip -j publish/$file_name bin/Release/netcoreapp3.1/$target/publish/nups_patcher
done

target="win-x64"
echo "building $target"
file_name="nups_patcher_${target}_$version.zip"
dotnet publish -r $target
zip -j publish/$file_name bin/Release/netcoreapp3.1/$target/publish/nups_patcher.exe
