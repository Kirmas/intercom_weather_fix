# intercom_weather_fix
If your ARMY AVD-1060 don't show weather after update your IP dont available in their BD. I fixed this locally using local DNS server.
1. Set up any DNS server I use bind9 and this(https://www.digitalocean.com/community/questions/adding-a-second-domain-name-with-bind9) instruction.
2. Redirect http://icanhazip.com/ to you local network server.
3. Change [Location.txt](./intercom_weather_fix/wwwroot/Location.txt) to other IP adress (it must be your local city provider) 
   > You can chack IP adress using https://api.seniverse.com/v3/weather/now.json?key=SxTmZ8QZRW5fvG_C0&location=[ip_to_check]&language=en&unit=c&start=0&days=5 (Intercom use this api)
4. Publish solution for your server OS.
5. Use Apache or Nginx to proxy 80 port to your dot.net port.
