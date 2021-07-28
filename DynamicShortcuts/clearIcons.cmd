taskkill /f /im explorer.exe
cd /d %userprofile%\AppData\Local\Microsoft\Windows\Explorer
del iconcache_16.db /a
del iconcache_32.db /a
del iconcache_48.db /a
del iconcache_96.db /a
del iconcache_256.db /a
del iconcache_768.db /a
del iconcache_1280.db /a
del iconcache_1920.db /a
del iconcache_2560.db /a
del iconcache_custom_stream.db /a
del iconcache_exif.db /a
del iconcache_idx.db /a
del iconcache_sr.db /a
del iconcache_wide.db /a
del iconcache_wide_alternate.db /a
start explorer.exe