### .NET solution generator guide
This wizard generates .NET solution files according to your project structure.

#### **Display help screen**
    $ dotnet-solution-generator \
        --help

#### **Generate solution from directory**
    $ dotnet-solution-generator \
        --generate-solution-from-directory \
        --source "." \
        --name "MySolution"

#### **Generate solution from makefile**
First, generate makefile.

    $ dotnet-solution-generator \
        --generate-makefile \
        --source "." \
        --name "MySolution"

Second, edit makefile to your needs.

    $ code "./MySolution.sln_mk.json"

Third, generate solution from makefile.

    $ dotnet-solution-generator \
        --generate-solution-from-makefile \
        --source "./MySolution.sln_mk.json" \
        --name "MySolution"
