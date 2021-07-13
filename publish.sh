set -e

version="1.0.0"
targets=("linux-x64" "osx-x64")

mkdir -p publish
rm -f publish/*
rm -rf bin
rm -rf obj

for target in ${targets[@]}; do
  echo "building $target"
  file_name="nups_patcher_${target}_$version"
  dotnet publish -r $target
  pushd bin/Release/netcoreapp3.1/$target/publish
  mv nups_patcher $file_name
  popd
  zip -j publish/$file_name.zip bin/Release/netcoreapp3.1/$target/publish/$file_name
done

target="win-x64"
echo "building $target"
file_name="nups_patcher_${target}_$version.exe"
dotnet publish -r $target
pushd bin/Release/netcoreapp3.1/$target/publish
mv nups_patcher.exe $file_name
popd
zip -j publish/nups_patcher_${target}_$version.zip bin/Release/netcoreapp3.1/$target/publish/$file_name
