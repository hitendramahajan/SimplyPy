import urllib3

def fetch_url(url):
    http = urllib3.PoolManager()
    try:
        response = http.request('GET', url)
        print(f"Status: {response.status}")
        print(f"Data: {response.data.decode('utf-8')[:200]}")  # Print the first 200 characters of the response
    except urllib3.exceptions.HTTPError as e:
        print(f"HTTP error: {e}")
    except Exception as e:
        print(f"Error: {e}")
