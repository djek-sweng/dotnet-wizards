### .NET solution generator guide
This wizard generates .NET solution files according to your project structure.

#### **Display help screen**
    $ dotnet-solution-generator \
        --help

#### **Generate solution from directory**
    $ dotnet-solution-generator \
        --generate-solution-from-directory \
        --source "." \
        --name "MySolutionTest"

#### **Generate solution from makefile**
First, generate makefile.

    $ dotnet-solution-generator \
        --generate-makefile \
        --source "." \
        --name "MySolutionTest"

Second, edit makefile to your needs.

    $ code "./MySolutionTest.sln_mk.json"

Third, generate solution from makefile.

    $ dotnet-solution-generator \
        --generate-solution-from-makefile \
        --source "./MySolutionTest.sln_mk.json" \
        --name "MySolutionTest"
