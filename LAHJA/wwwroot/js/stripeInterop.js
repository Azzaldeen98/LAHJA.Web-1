window.stripeSubscribe = {
    stripe: null,
    elements: null,

    initializeStripe: function (publishableKey, clientSecret) {
        this.stripe = Stripe(publishableKey);

        const options = {
            clientSecret: clientSecret,
            appearance: { /* https://docs.stripe.com/elements/appearance-api */

                theme: 'stripe',
            },
            locale: "en" // تحديد اللغة 
        };

        this.elements = this.stripe.elements(options);

        const paymentElementOptions = {
            layout: "tabs"
        };

        const paymentElement = this.elements.create("payment", paymentElementOptions);
        paymentElement.mount("#payment-element");

    },

    processPayment: async function (clientSecret, dotnetHelper) {
        const { error } = await this.stripe.confirmPayment({
            elements: this.elements,
            confirmParams: {
                return_url: "https://localhost:5002" // استبدل بعنوان نجاح الدفع
            }
        });

        if (error) {
            dotnetHelper.invokeMethodAsync("OnPaymentFailed", error.message);
        } else {
            dotnetHelper.invokeMethodAsync("OnPaymentSuccess","success");
        }
    }
};

window.stripeCustomerSession = {
    stripe: null,
    elements: null,

    initializeStripe: function (publishableKey, customerSessionClientSecret) {
        this.stripe = Stripe(publishableKey);
        const options = {
            mode: 'setup',
            currency: 'usd',
            customerSessionClientSecret,
            appearance: { /* https://docs.stripe.com/elements/appearance-api */

                theme: 'stripe',
            },
            locale: "en" // تحديد اللغة 
        };

        this.elements = this.stripe.elements(options);
        const paymentElementOptions = {
            layout: {
                type: 'accordion',
                defaultCollapsed: false
} };

        const paymentElement = this.elements.create("payment", paymentElementOptions);
        paymentElement.mount("#payment-element");
    },

    processPayment: async function (dotnetHelper) {
        const { setupIntent, error } = await this.stripe.confirmCardSetup(clientSecret, {
            payment_method: { card: this.cardElement }
        });

        if (error) {
            dotnetHelper.invokeMethodAsync("OnPaymentFailed", error.message);
        } else {
            dotnetHelper.invokeMethodAsync("OnPaymentSuccess", setupIntent.payment_method);
        }
    }
};

window.stripePaymentMethod = {
    stripe: null,
    elements: null,

    initializeStripe: function (publishableKey, clientSecret) {
        this.stripe = Stripe(publishableKey);

        const options = {
            clientSecret: clientSecret,
            appearance: { /* https://docs.stripe.com/elements/appearance-api */

                theme: 'stripe',
            },
            locale: "en" // تحديد اللغة 
        };

        this.elements = this.stripe.elements(options);

        const paymentElementOptions = {
            layout: "accordion",
            fields: {
                billingDetails: {
                    // No address field will be collected in any of the payment method forms
                    //address: 'auto',
                }
            }
        };

        const paymentElement = this.elements.create("payment", paymentElementOptions);
        const addressElement = this.elements.create("address", {
            mode:'shipping'
        });
        paymentElement.mount("#payment-element");
        addressElement.mount("#address-element");

    },

    processPayment: async function (clientSecret, dotnetHelper) {
        const { setupIntent, error } = await this.stripe.confirmSetup({
            elements: this.elements,
            confirmParams: {
                return_url: "https://localhost:5002" // استبدل بعنوان نجاح الدفع
            },
            // عند الرجوع الى صفحة ارخرى من  هنا فانه تحدث مشكله في السطر الذي يتم فيه استدعاء هذه الداله
            //وذلك لان التطبيق يتوقع البقاء في نفس الصفحة
            redirect: "if_required" // يمنع إعادة التوجيه إذا لم يكن ضروريًا
        });

        if (error) {
            dotnetHelper.invokeMethodAsync("OnPaymentFailed", error.message);
        } else {
            dotnetHelper.invokeMethodAsync("OnPaymentSuccess", setupIntent.id);
        }
    }
};
