﻿(function ($) {
    var ChangeContactInfoViewModel = (function () {
        var ctor = function () {
            this.rootElement = $('#companyContactInfoPane');
            this.originalId = this.rootElement.data('originalId');
            this.changeContactInfoUrl = this.rootElement.data('url');

            this.model = {};
            this._copyInitialValues();
        };

        ctor.prototype._copyInitialValues = function () {
            this.model = {
                phone: this.rootElement.find('.contact-phone').html().trim(),
                fax: this.rootElement.find('.contact-fax').html().trim(),
                website: this.rootElement.find('.contact-website').html().trim(),
                email: this.rootElement.find('.contact-email').html().trim()
            };
        };

        ctor.prototype._replaceWithInputs = function () {
            var phoneInput = $('<input type="tel" class="form-control" />')
            phoneInput.val(this.model.phone);
            this.rootElement.find('.contact-phone').html(phoneInput);

            var faxInput = $('<input type="text" class="form-control" />')
            faxInput.val(this.model.fax);
            this.rootElement.find('.contact-fax').html(faxInput);

            var websiteInput = $('<input type="text" class="form-control" />')
            websiteInput.val(this.model.website);
            this.rootElement.find('.contact-website').html(websiteInput);

            var emailInput = $('<input type="email" class="form-control" />')
            emailInput.val(this.model.email);
            this.rootElement.find('.contact-email').html(emailInput);
        };

        ctor.prototype._replaceWithValues = function () {
            this.rootElement.find('.contact-phone').html(this.model.phone);
            this.rootElement.find('.contact-fax').html(this.model.fax);
            this.rootElement.find('.contact-website').html(this.model.website);
            this.rootElement.find('.contact-email').html(this.model.email);
        };

        ctor.prototype.enableEdit = function () {
            this.rootElement.find('#changeContactInfoBtn').addClass('hidden');
            this._replaceWithInputs();
            this.rootElement.find('.change-contact-info-actions').removeClass('hidden');
        };

        ctor.prototype.cancel = function () {
            this.rootElement.find('.change-contact-info-actions').addClass('hidden');
            this._replaceWithValues();
            this.rootElement.find('#changeContactInfoBtn').removeClass('hidden');
        };

        ctor.prototype.save = function () {
            this.rootElement.find('.change-contact-info-actions > button').prop('disabled', true);
            var values = {
                CompanyId: this.originalId,
                PhoneNumber: this.rootElement.find('.contact-phone > input').val(),
                FaxNumber: this.rootElement.find('.contact-fax > input').val(),
                WebsiteAddress: this.rootElement.find('.contact-website > input').val(),
                EmailAddress: this.rootElement.find('.contact-email > input').val()
            };

            var self = this;
            $.ajax(this.changeContactInfoUrl, {
                method: 'POST',
                data: values
            }).done(function (data, textStatus) {
                self.model.phone = values.PhoneNumber;
                self.model.fax = values.FaxNumber;
                self.model.website = values.WebsiteAddress;
                self.model.email = values.EmailAddress;

                self.cancel();
                self.rootElement.find('.change-contact-info-actions > button').prop('disabled', false);
                alert('Contact info changed correctly');
            }).fail(function (xhr, textStatus, errorThrown) {
                self.rootElement.find('.change-contact-info-actions > button').prop('disabled', false);
                alert('There was an error changing this info');
            });
        };

        return ctor;
    }());

    var ChangeShippingAddressViewModel = (function () {
        var ctor = function () {
            this.rootElement = $('#shippingAddressPane');
            this.originalId = this.rootElement.data('originalId');
            this.changeShippingAddressUrl = this.rootElement.data('url');
            this.model = {};
            this._copyInitialValues();
        };

        ctor.prototype._copyInitialValues = function () {
            this.model = {
                address: this.rootElement.find('.address').html().trim(),
                postalCode: this.rootElement.find('.postal-code').html().trim(),
                city: this.rootElement.find('.city').html().trim(),
                country: this.rootElement.find('.country').html().trim(),
                province: this.rootElement.find('.province').html().trim(),
            };
        };

        ctor.prototype._replaceWithValues = function () {
            this.rootElement.find('.address').html(this.model.address);
            this.rootElement.find('.postal-code').html(this.model.postalCode);
            this.rootElement.find('.city').html(this.model.city);
            this.rootElement.find('.country').html(this.model.country);
            this.rootElement.find('.province').html(this.model.province);
            this.rootElement.find('.shipping-effective-date').remove();
        };

        ctor.prototype._replaceWithInputs = function () {
            var addressInput = $('<input type="text" class="form-control" />');
            addressInput.val(this.model.address);
            this.rootElement.find('.address').html(addressInput);

            var postalCodeInput = $('<input type="text" class="form-control" />');
            postalCodeInput.val(this.model.postalCode);
            this.rootElement.find('.postal-code').html(postalCodeInput);

            var cityInput = $('<input type="text" class="form-control" />');
            cityInput.val(this.model.city);
            this.rootElement.find('.city').html(cityInput);

            var countryInput = $('<input type="text" class="form-control" />');
            countryInput.val(this.model.country);
            this.rootElement.find('.country').html(countryInput);

            var provinceInput = $('<input type="text" class="form-control" />');
            provinceInput.val(this.model.province);
            this.rootElement.find('.province').html(provinceInput);

            var effectiveDate = $('<dt class="shipping-effective-date">Effective date</dt><dd class="shipping-effective-date effective-date-input"><input type="date" class="form-control" /></dd>');
            this.rootElement.find('.province').after(effectiveDate);
        };

        ctor.prototype.enableEdit = function () {
            this.rootElement.find('#changeShippingAddressBtn').addClass('hidden');
            this._replaceWithInputs();
            this.rootElement.find('.change-shipping-address-actions').removeClass('hidden');
        };

        ctor.prototype.cancel = function () {
            this.rootElement.find('.change-shipping-address-actions').addClass('hidden');
            this._replaceWithValues();
            this.rootElement.find('#changeShippingAddressBtn').removeClass('hidden');
        };

        ctor.prototype.save = function () {
            this.rootElement.find('.change-shipping-address-actions > button').prop('disabled', true);
            var values = {
                CompanyId: this.originalId,
                ShippingAddress: {
                    Address: this.rootElement.find('.address > input').val(),
                    City: this.rootElement.find('.city > input').val(),
                    PostalCode: this.rootElement.find('.postal-code > input').val(),
                    Province: this.rootElement.find('.province > input').val(),
                    Country: this.rootElement.find('.country > input').val()
                },
                EffectiveDate: this.rootElement.find('.shipping-effective-date.effective-date-input > input').val()
            };

            var self = this;
            $.ajax(this.changeShippingAddressUrl, {
                method: 'POST',
                data: values
            }).done(function (data, textStatus) {
                self.model.address = values.ShippingAddress.Address;
                self.model.city = values.ShippingAddress.City;
                self.model.postalCode = values.ShippingAddress.PostalCode;
                self.model.province = values.ShippingAddress.Province;
                self.model.country = values.ShippingAddress.Country;

                self.cancel();
                self.rootElement.find('.change-shipping-address-actions > button').prop('disabled', false);
                alert('Address changed correctly');
            }).fail(function (xhr, textStatus, errorThrown) {
                self.rootElement.find('.change-shipping-address-actions > button').prop('disabled', false);
                alert('There was an error changing the address');
            });
        };

        return ctor;
    }());

    var ChangeBillingAddressViewModel = (function () {
        var ctor = function () {
            this.rootElement = $('#billingAddressPane');
            this.originalId = this.rootElement.data('originalId');
            this.changeBillingAddressUrl = this.rootElement.data('url');
            this.model = {};
            this._copyInitialValues();
        };

        ctor.prototype._copyInitialValues = function () {
            this.model = {
                address: this.rootElement.find('.address').html().trim(),
                postalCode: this.rootElement.find('.postal-code').html().trim(),
                city: this.rootElement.find('.city').html().trim(),
                country: this.rootElement.find('.country').html().trim(),
                province: this.rootElement.find('.province').html().trim(),
            };
        };

        ctor.prototype._replaceWithValues = function () {
            this.rootElement.find('.address').html(this.model.address);
            this.rootElement.find('.postal-code').html(this.model.postalCode);
            this.rootElement.find('.city').html(this.model.city);
            this.rootElement.find('.country').html(this.model.country);
            this.rootElement.find('.province').html(this.model.province);
            this.rootElement.find('.billing-effective-date').remove();
        };

        ctor.prototype._replaceWithInputs = function () {
            var addressInput = $('<input type="text" class="form-control" />');
            addressInput.val(this.model.address);
            this.rootElement.find('.address').html(addressInput);

            var postalCodeInput = $('<input type="text" class="form-control" />');
            postalCodeInput.val(this.model.postalCode);
            this.rootElement.find('.postal-code').html(postalCodeInput);

            var cityInput = $('<input type="text" class="form-control" />');
            cityInput.val(this.model.city);
            this.rootElement.find('.city').html(cityInput);

            var countryInput = $('<input type="text" class="form-control" />');
            countryInput.val(this.model.country);
            this.rootElement.find('.country').html(countryInput);

            var provinceInput = $('<input type="text" class="form-control" />');
            provinceInput.val(this.model.province);
            this.rootElement.find('.province').html(provinceInput);

            var effectiveDate = $('<dt class="billing-effective-date">Effective date</dt><dd class="billing-effective-date effective-date-input"><input type="date" class="form-control" /></dd>');
            this.rootElement.find('.province').after(effectiveDate);
        };

        ctor.prototype.enableEdit = function () {
            this.rootElement.find('#changeBillingAddressBtn').addClass('hidden');
            this._replaceWithInputs();
            this.rootElement.find('.change-billing-address-actions').removeClass('hidden');
        };

        ctor.prototype.cancel = function () {
            this.rootElement.find('.change-billing-address-actions').addClass('hidden');
            this._replaceWithValues();
            this.rootElement.find('#changeBillingAddressBtn').removeClass('hidden');
        };

        ctor.prototype.save = function () {
            this.rootElement.find('.change-billing-address-actions > button').prop('disabled', true);
            var values = {
                CompanyId: this.originalId,
                BillingAddress: {
                    Address: this.rootElement.find('.address > input').val(),
                    City: this.rootElement.find('.city > input').val(),
                    PostalCode: this.rootElement.find('.postal-code > input').val(),
                    Province: this.rootElement.find('.province > input').val(),
                    Country: this.rootElement.find('.country > input').val()
                },
                EffectiveDate: this.rootElement.find('.billing-effective-date.effective-date-input > input').val()
            };

            var self = this;
            $.ajax(this.changeBillingAddressUrl, {
                method: 'POST',
                data: values
            }).done(function (data, textStatus) {
                self.model.address = values.BillingAddress.Address;
                self.model.city = values.BillingAddress.City;
                self.model.postalCode = values.BillingAddress.PostalCode;
                self.model.province = values.BillingAddress.Province;
                self.model.country = values.BillingAddress.Country;

                self.cancel();
                self.rootElement.find('.change-billing-address-actions > button').prop('disabled', false);
                alert('Address changed correctly');
            }).fail(function (xhr, textStatus, errorThrown) {
                self.rootElement.find('.change-billing-address-actions > button').prop('disabled', false);
                alert('There was an error changing the address');
            });
        };

        return ctor;
    }());

    var ChangeLegalAddressViewModel = (function () {
        var ctor = function () {
            this.rootElement = $('#legalAddressPane');
            this.originalId = this.rootElement.data('originalId');
            this.changeLegalAddressUrl = this.rootElement.data('url');
            this.model = {};
            this._copyInitialValues();
        };

        ctor.prototype._copyInitialValues = function () {
            this.model = {
                address: this.rootElement.find('.address').html().trim(),
                postalCode: this.rootElement.find('.postal-code').html().trim(),
                city: this.rootElement.find('.city').html().trim(),
                country: this.rootElement.find('.country').html().trim(),
                province: this.rootElement.find('.province').html().trim(),
            };
        };

        ctor.prototype._replaceWithValues = function () {
            this.rootElement.find('.address').html(this.model.address);
            this.rootElement.find('.postal-code').html(this.model.postalCode);
            this.rootElement.find('.city').html(this.model.city);
            this.rootElement.find('.country').html(this.model.country);
            this.rootElement.find('.province').html(this.model.province);
            this.rootElement.find('.legal-effective-date').remove();
        };

        ctor.prototype._replaceWithInputs = function () {
            var addressInput = $('<input type="text" class="form-control" />');
            addressInput.val(this.model.address);
            this.rootElement.find('.address').html(addressInput);

            var postalCodeInput = $('<input type="text" class="form-control" />');
            postalCodeInput.val(this.model.postalCode);
            this.rootElement.find('.postal-code').html(postalCodeInput);

            var cityInput = $('<input type="text" class="form-control" />');
            cityInput.val(this.model.city);
            this.rootElement.find('.city').html(cityInput);

            var countryInput = $('<input type="text" class="form-control" />');
            countryInput.val(this.model.country);
            this.rootElement.find('.country').html(countryInput);

            var provinceInput = $('<input type="text" class="form-control" />');
            provinceInput.val(this.model.province);
            this.rootElement.find('.province').html(provinceInput);

            var effectiveDate = $('<dt class="legal-effective-date">Effective date</dt><dd class="legal-effective-date effective-date-input"><input type="date" class="form-control" /></dd>');
            this.rootElement.find('.province').after(effectiveDate);
        };

        ctor.prototype.enableEdit = function () {
            this.rootElement.find('#changeLegalAddressBtn').addClass('hidden');
            this._replaceWithInputs();
            this.rootElement.find('.change-legal-address-actions').removeClass('hidden');
        };

        ctor.prototype.cancel = function () {
            this.rootElement.find('.change-legal-address-actions').addClass('hidden');
            this._replaceWithValues();
            this.rootElement.find('#changeLegalAddressBtn').removeClass('hidden');
        };

        ctor.prototype.save = function () {
            this.rootElement.find('.change-legal-address-actions > button').prop('disabled', true);
            var values = {
                CompanyId: this.originalId,
                LegalAddress: {
                    Address: this.rootElement.find('.address > input').val(),
                    City: this.rootElement.find('.city > input').val(),
                    PostalCode: this.rootElement.find('.postal-code > input').val(),
                    Province: this.rootElement.find('.province > input').val(),
                    Country: this.rootElement.find('.country > input').val()
                },
                EffectiveDate: this.rootElement.find('.legal-effective-date.effective-date-input > input').val()
            };

            var self = this;
            $.ajax(this.changeLegalAddressUrl, {
                method: 'POST',
                data: values
            }).done(function (data, textStatus) {
                self.model.address = values.LegalAddress.Address;
                self.model.city = values.LegalAddress.City;
                self.model.postalCode = values.LegalAddress.PostalCode;
                self.model.province = values.LegalAddress.Province;
                self.model.country = values.LegalAddress.Country;

                self.cancel();
                self.rootElement.find('.change-legal-address-actions > button').prop('disabled', false);
                alert('Address changed correctly');
            }).fail(function (xhr, textStatus, errorThrown) {
                self.rootElement.find('.change-legal-address-actions > button').prop('disabled', false);
                alert('There was an error changing the address');
            });
        };

        return ctor;
    }());

    $(document).ready(function () {
        var changeShippingAddress = new ChangeShippingAddressViewModel();
        var changeBillingAddress = new ChangeBillingAddressViewModel();
        var changeLegalAddress = new ChangeLegalAddressViewModel();
        var changeContactInfo = new ChangeContactInfoViewModel();

        $('#changeContactInfoBtn').click(function (e) {
            e.preventDefault();
            changeContactInfo.enableEdit();
        });

        $('#cancelContactInfo').click(function (e) {
            e.preventDefault();
            changeContactInfo.cancel();
        });

        $('#saveContactInfo').click(function (e) {
            e.preventDefault();
            changeContactInfo.save();
        });

        $('#changeShippingAddressBtn').click(function (e) {
            e.preventDefault();
            changeShippingAddress.enableEdit();
        });

        $('#cancelShippingAddress').click(function (e) {
            e.preventDefault();
            changeShippingAddress.cancel();
        });

        $('#saveShippingAddress').click(function (e) {
            e.preventDefault();
            changeShippingAddress.save();
        });

        $('#changeBillingAddressBtn').click(function (e) {
            e.preventDefault();
            changeBillingAddress.enableEdit();
        });

        $('#cancelBillingAddress').click(function (e) {
            e.preventDefault();
            changeBillingAddress.cancel();
        });

        $('#saveBillingAddress').click(function (e) {
            e.preventDefault();
            changeBillingAddress.save();
        });

        $('#changeLegalAddressBtn').click(function (e) {
            e.preventDefault();
            changeLegalAddress.enableEdit();
        });

        $('#cancelLegalAddress').click(function (e) {
            e.preventDefault();
            changeLegalAddress.cancel();
        });

        $('#saveLegalAddress').click(function (e) {
            e.preventDefault();
            changeLegalAddress.save();
        });
    });
}(jQuery));