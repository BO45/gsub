## Overview ##

A smart git-subtree tool that just works.


<!-- TOC -->

- [Overview](#overview)
- [Verbs](#verbs)
- [Parameters](#parameters)
    - [add](#add)
    - [remove](#remove)
    - [rename](#rename)
    - [list](#list)
    - [pull](#pull)
    - [push](#push)
- [Installation](#installation)
    - [All platforms when dotnet is installed](#all-platforms-when-dotnet-is-installed)
    - [Windows](#windows)
    - [Ubuntu](#ubuntu)
    - [Redhat / CentOS](#redhat--centos)
    - [MacOS](#macos)
- [ToDo](#todo)

<!-- /TOC -->


## Verbs ##
```
  add        Adds a subtree alias

  list       Lists currently managed subtrees

  remove     Removes a subtree alias

  pull       Pulls from a subtree alias

  push       Pushes to a subtree alias

  rename     Renames an alias
```

## Parameters ##

### add ###

```
USAGE:
Normal scenario:
  gsub add --alias remote1 --prefix remote1/src --ref master --squash --url https://github.com/remote1

  -a, --alias      Required. Alias to use for subtree

  -p, --prefix     Required. Prefix path to subtree

  -u, --url        Required. Remote URL of subtree

  -r, --ref        Required. Ref like master

  -s, --squash     Squash commits
```

Adds a subtree alias to the repo. Future operations can then access it by referencing the alias.

### remove ###

```
USAGE:                                                        
Normal scenario:                                              
  gsub remove --alias remote1                                 
                                                              
  -a, --alias      Required. Alias to subtree                 
                                                              
  -v, --verbose    Increase verbose output                    

```

Removes an alias from the configuration file.

### rename ###

```
USAGE:
Normal scenario:
  gsub rename --from remote1 --to remote2

  -f, --from       Required. Original alias name

  -t, --to         Required. New alias name
```

Renames an alias.

### list ###

```
USAGE:
Normal scenario:
  gsub list

  -v, --verbose    Increase verbose output

```

Lists all aliases stored for this repo.

### pull ###

```
USAGE:
Normal scenario:
  gsub pull --alias remote1 --ref develop --squash

  -a, --alias      Required. Alias to subtree

  -r, --ref        Alternative ref, other than the one used when added

  -s, --squash     Squash commits

  -v, --verbose    Increase verbose output

```

Pulls changes from an alias. Optional ref to override default branch.

### push ###

```
USAGE:
Normal scenario:
  gsub push --alias remote1 --ref develop --squash

  -a, --alias      Required. Alias to subtree

  -r, --ref        Alternative ref, other than the one used when added

  -s, --squash     Squash commits

  -v, --verbose    Increase verbose output
```

Pushes changes to an alias. Optional ref to override default branch.

## Installation ##

[Requires .NET Standard 2.0 (preview)](https://www.microsoft.com/net/core/preview#windowscmd)

### All platforms when dotnet is installed ###

```
cd gsub
dotnet run --project gsub\gsub.csproj
```

### Windows ###

```
cd gsub
dotnet restore
dotnet publish -c release -r "win10-x64"
```

### Ubuntu ###

```
cd gsub
dotnet restore
dotnet publish -c release -r ubuntu.16.10-x64 -o ~/gsubpub/
```

### Redhat / CentOS ###

```
cd gsub
dotnet restore
dotnet publish -c release -r "centos.7-x64" -o ~/gsubpub/
```

### MacOS ###

```
cd gsub
dotnet restore
dotnet publish -c release -r osx.10.11-x64 -o ~/gsubpub/
```


## ToDo ##

  * ~~Rename aliases. This can manually be done by editing the configuration file without any side-effects.~~
  * Merge operations from specific commits
  * Automatically split out prefixes to branches and commit
  

