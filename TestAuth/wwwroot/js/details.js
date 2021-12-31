google.maps.event.addDomListener(window, 'load', intilize);
function intilize() {
    var autocomplete = new google.maps.places.Autocomplete(document.getElementById('textId'));

    google.maps.event.addListener(autocomplete, 'place_changed', function () {
        var place = autocomplete.getPlace();
        var latFir = place.geometry.location.lat();
        var lngFir = place.geometry.location.lng();
        var location = "<b>Первый адрес: </b>" + place.formatted_address + "<br/>";
        location += "<b>широта: </b>" + latFir + "<br/>";
        location += "<b> долгота: </b>" + lngFir;
        document.getElementById('lblid').innerHTML = location
    });
}
google.maps.event.addDomListener(window, 'load', intilizee);
function intilizee() {
    var autocompletee = new google.maps.places.Autocomplete(document.getElementById('textId2'));

    google.maps.event.addListener(autocompletee, 'place_changed', function () {
        var placee = autocompletee.getPlace();
        var latLas = placee.geometry.location.lat();
        var lngLas = placee.geometry.location.lng();
        var location = "<b>Конечный адрес: </b>" + placee.formatted_address + "<br/>";
        location += "<b>широта: </b>" + latLas + "<br/>";
        location += "<b> долгота: </b>" + lngLas
        document.getElementById('lblid2').innerHTML = location

    });
}

function initMap() {
    const directionsRenderer = new google.maps.DirectionsRenderer();
    const directionsService = new google.maps.DirectionsService();
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 10,
        center: { lat: 38.6076158, lng: 68.7869588 },
    });

    directionsRenderer.setMap(map);
    calculateAndDisplayRoute(directionsService, directionsRenderer);
    document.getElementById("mode").addEventListener("change", () => {
        calculateAndDisplayRoute(directionsService, directionsRenderer);
    });
}

function calculateAndDisplayRoute(directionsService, directionsRenderer) {
    const selectedMode = document.getElementById("mode").value;

    directionsService
        .route({
            origin: { lat: 38.6076158, lng: 68.7869588 },
            destination: { lat: 37.8335715, lng: 68.78446679999999 },
            travelMode: google.maps.TravelMode[selectedMode],
        })
        .then((response) => {
            directionsRenderer.setDirections(response);
        })
}

function myFunction() {
    var x = document.getElementById("myDIV");
    if (x.style.display === "block") {
        x.style.display = "none";
    } else {
        x.style.display = "block";
    }
}