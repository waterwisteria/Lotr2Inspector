# Lotr2Inspector

Memory inspector for LOTR2.

- Generates Cheat Engine town table for all towns and their mapped properties
- Has most memory regions mapped
  - all 16 towns
  - viewport
  - moveables (merchants, armies, etc)
  - map and town names

Reads with kernel32.dll ReadProcessMemory, does not yet write but that's coming (meant to be a trainer right ;)).
