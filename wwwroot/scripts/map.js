function initMap() {

    // Get list of markers and map centre from data- attribute
    var mapElement = document.getElementById('map');
    var lat = mapElement.dataset.lat;
    var lng = mapElement.dataset.lng;
    var locations = JSON.parse(mapElement.dataset.mapMarkers);
    
    // Create map
    var mapCentre = new google.maps.LatLng(lat, lng);
    var map = new google.maps.Map(mapElement, {
        zoom: 13,
        center: mapCentre
    });

    // Loop through markers and add to map
    var marker;
    var infowindow = new google.maps.InfoWindow();
    for (var i = 0; i < locations.length; i++) {

        // Get marker and position
        var position = new google.maps.LatLng(locations[i].latitude, locations[i].longitude);
        
        // Add the marker to the map
        marker = new google.maps.Marker({
            position: position,
            map: map
        });       

        // Add the name to the marker
        google.maps.event.addListener(marker, 'click', (function(marker, i) {
            return function() {
                infowindow.setContent(locations[i].name);
                infowindow.open(map, marker);
            }
        })(marker, i));        
    }    
}