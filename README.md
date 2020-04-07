# git-bulker
git bulk operations for multi repositories management 

## Features

### Discovering
- Project scope
- Discover all git repositories by specified root foler
- List Status of all repositories (current branch, up/down commits, last updated, last commit)
- Group repositories by folders
- Group repositories by remote sources
- Group repositories by issues/stories
- Group repositories by tags
- Search folder/remote sources/issues
- Recent actions
- Stale branches (no update, no commit for a period of time, e.g. 4 weeks)
- pin repository to certain version

### Updating
- specify update from develop/master
- check and list repositories not on develop/master, and display current branch, last updated time and last commit time, pending changes
- option to check all and switch to develop/master

### Pushing
- check branch not on develop/master, else warning out, and user can force push
- push multiple by issues
- push multiple by tags
- push multiple by folders

## Checkout
- can group checkout repositories to the same branch (per tag)

## Switch
- can group switch branches (per tag)
