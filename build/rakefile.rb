require 'rubygems'
require 'albacore'
require 'rake/clean'
require 'fileutils'

VERSION = "0.5.0"
OUTPUT = "output"
CONFIGURATION = 'Release'
SHARED_ASSEMBLY_INFO = '../source/SharedAssemblyInfo.cs'
SOLUTION_FILE = '../source/LetMeRate.sln'
ENVIRONMENT = ENV["env"] || "dev"
DEPLOY_PATH = 'C:/Websites/LetMeRate'


Albacore.configure do |config|
	config.log_level = :verbose
	config.msbuild.use :net4
end

desc "Compiles solution and runs unit tests"
task :default => [:version, :build, :create_db, :nunit, :build_package, :deploy]


#Add the folders that should be cleaned as part of the clean task
CLEAN.include(OUTPUT)
CLEAN.include(FileList["../source/**/#{CONFIGURATION}"])


task :deploy do
 mkdir_p DEPLOY_PATH
 cp_r "#{OUTPUT}/.", DEPLOY_PATH
 mv Dir.pwd + "/#{OUTPUT}/web.config.#{ENVIRONMENT}", "#{DEPLOY_PATH}/web.config"
end



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


desc "Build solution file with package"
msbuild :build => [:version] do |msb|
	msb.properties =
	{
		:configuration => CONFIGURATION
	}
	msb.targets :Clean, :Build
	msb.solution = SOLUTION_FILE
end


desc "Build solution file with package"
msbuild :build_package => [:version] do |msb|
	msb.properties =
	{
		:configuration => CONFIGURATION, 
		:webprojectoutputdir => "../../Build/#{OUTPUT}",
		:outdir => "../../Build/#{OUTPUT}/bin/"
	}
	msb.targets :Clean, :Build
	msb.solution = SOLUTION_FILE
end

desc "NUnit Test Runner"
nunit do |nunit|
	puts Dir.pwd
	tests = FileList["../source/**/#{CONFIGURATION}/*.Specs.dll"].exclude(/obj\//)
	nunit.command = "tools/nunit/net-2.0/nunit-console.exe"
	nunit.assemblies = tests
end




desc "Run the database scripts"
sqlcmd :create_db do |sql|
  
  scripts = FileList["sql-scripts/*.sql"]
  puts scripts
  
  sql.command = "sqlcmd.exe"
  sql.server = ".\\SQLEXPRESS"
  sql.scripts = scripts
end

desc "Zips up the output"
zip :package => [:publish] do |zip|
	Dir.mkdir("#{OUTPUT}/packages")

	zip.directories_to_zip "#{OUTPUT}/binaries"
	zip.output_file = "Comments-#{VERSION}.zip"
	zip.output_path = "#{OUTPUT}/packages"
end


#TODO
# - Integration changes (sql scripts)
# - better deployment with IIS integration - modify hosts file etc.
