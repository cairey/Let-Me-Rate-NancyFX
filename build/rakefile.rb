require 'rubygems'
require 'albacore'
require 'rake/clean'

VERSION = "0.5.0"
OUTPUT = "output"
CONFIGURATION = 'Release'
SHARED_ASSEMBLY_INFO = '../source/SharedAssemblyInfo.cs'
SOLUTION_FILE = '../source/LetMeRate.sln'

Albacore.configure do |config|
	config.log_level = :verbose
	config.msbuild.use :net4
end

desc "Compiles solution and runs unit tests"
task :default => [:clean, :version, :compile, :nunit]

desc "Executes all MSpec and Xunit tests"
task :test => [:mspec, :xunit]

#Add the folders that should be cleaned as part of the clean task
CLEAN.include(OUTPUT)
CLEAN.include(FileList["../source/**/#{CONFIGURATION}"])

desc "Update shared assemblyinfo file for the build"
assemblyinfo :version => [:clean] do |asm|
	asm.version = VERSION
	asm.company_name = "Christopher Airey"
	asm.product_name = "Let Me Rate"
	asm.title = "Let Me Rate"
	asm.description = "Let Me Rate for .NET"
	asm.copyright = "Copyright (C) Christopher Airey and contributors"
	asm.output_file = SHARED_ASSEMBLY_INFO
end

desc "Compile solution file"
msbuild :compile => [:version] do |msb|
	msb.properties :configuration => CONFIGURATION
	msb.targets :Clean, :Build
	msb.solution = SOLUTION_FILE
end

desc "NUnit Test Runner"
nunit do |nunit|

	tests = FileList["../source/**/#{CONFIGURATION}/*.Specs.dll"].exclude(/obj\//)
	nunit.command = "tools/nunit/net-2.0/nunit-console.exe"
	nunit.assemblies = tests
end


desc "Gathers output files and copies them to the output folder"
task :publish => [:compile] do
	Dir.mkdir(OUTPUT)
	Dir.mkdir("#{OUTPUT}/binaries")
	puts Dir.pwd
	puts Dir.pwd
	FileUtils.cp_r FileList["../source/**/#{CONFIGURATION}/*.dll"].exclude(/obj\//).exclude(/.Tests/), "#{OUTPUT}/binaries"
end



desc "Zips up the built binaries for easy distribution"
zip :package => [:publish] do |zip|
	Dir.mkdir("#{OUTPUT}/packages")

	zip.directories_to_zip "#{OUTPUT}/binaries"
	zip.output_file = "Comments-#{VERSION}.zip"
	zip.output_path = "#{OUTPUT}/packages"
end