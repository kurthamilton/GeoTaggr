(function () {
    const nullLatLng = { lat: 0, lng: 0 };

    function init(container, options) {        
        const map = new google.maps.Map(container, {
            zoom: 1,
            center: nullLatLng
        });
        map.addListener('click', e => {
            const latLong = {
                lat: e.latLng.lat(),
                lng: e.latLng.lng()
            };
            console.log(latLong);
        });

        const markers = [];
        options.markers.forEach(marker => {
            markers.push(new google.maps.Marker({
                position: { lat: marker.lat, lng: marker.long },
                map
            }));
        });      

        new markerClusterer.MarkerClusterer({
            map,
            markers
        });

    }

    window.gtgr = window.gtgr || {};
    window.gtgr.maps = {
        init: init
    };
})();